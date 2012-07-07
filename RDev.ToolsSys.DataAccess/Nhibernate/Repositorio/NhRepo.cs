using System;
using System.Collections.Generic;
using System.Configuration;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.Persister.Entity;
using NHibernate.Proxy;
using RDev.ToolsSys.Business.BaseRepositorio;

namespace RDev.ToolsSys.DataAccess.Nhibernate.Repositorio
{
    public class NhRepo<T> : ITransacaoRepositorio, ICrudRepositorio<T>
    {
        protected readonly ISession sessao;
        protected ITransaction transaction;
        

        public NhRepo(ISession sessao)
        {
            this.sessao = sessao;
           
        }

        public NhRepo()
        {
            this.sessao = NhSingleton.OpenSession();
            
        }

        /// <summary>
        /// Usado para aumentar o CommandTimeOut de queries que possam demorar mais.
        /// Se o valor nao for encontrado no .config, o valor padrao sera de 120 segundos.
        /// </summary>
        private int? _timeOutEstendido;
        public int TimeOutEstendido
        {
            get
            {
                if (_timeOutEstendido == null)
                {
                    _timeOutEstendido = ConfigurationManager.AppSettings["TimeOutEstendido"] != null
                                            ? Convert.ToInt32(ConfigurationManager.AppSettings["TimeOutEstendido"])
                                            : 120;
                }
                return (int)_timeOutEstendido;
            }
            set { _timeOutEstendido = value; }
        }

        public virtual void Salvar(T entidade)
        {
            using (var trans = sessao.BeginTransaction())
            {
                sessao.SaveOrUpdate(entidade);
                trans.Commit();
            }
        }

        public void LimparSessao()
        {
            sessao.Clear();
        }

        public virtual IList<T> Pesquisar(T entidade)
        {
            return Pesquisar(entidade, null);
        }

        public virtual IList<T> Pesquisar()
        {
            return sessao.CreateCriteria(typeof(T)).List<T>();
        }

        public virtual IList<T> Pesquisar(T entidade, List<ICriterion> criterias)
        {
            Example criterios = Example.Create(entidade).ExcludeZeroes();
            var id = (int)entidade.GetType().GetProperty("Id").GetValue(entidade, null);

            if (id == 0)
            {
                var query = sessao
                    .CreateCriteria(typeof(T))
                    .Add(criterios)
                    ;

                if (criterias != null)
                {
                    foreach (var criteria in criterias)
                    {
                        query.Add(criteria);
                    }
                    query.SetResultTransformer(CriteriaSpecification.DistinctRootEntity);
                }
                var retorno = query.List<T>();
                return retorno.Count == 0 ? null : retorno;
            }
            else
            {
                var retorno = sessao.Get<T>(id);
                return retorno == null ? null : new List<T> { retorno };
            }
        }

        public virtual T Pesquisar(int id)
        {
            var pesquisar = sessao.Get<T>(id);
            return pesquisar;
        }

        public virtual void Excluir(T entidade)
        {
            using (var trans = sessao.BeginTransaction())
            {
                sessao.Delete(entidade);
                
                trans.Commit();
            }
        }

        public void Excluir(int id)
        {
            using (var trans = sessao.BeginTransaction())
            {
                var foo = sessao.Get<T>(id);
                
                sessao.Delete(foo);
                trans.Commit();
            }
        }

        public void AtualizarObjeto(T entidade)
        {
            sessao.Refresh(entidade);
        }

        public void AtivarLazyLoad(Object entidade)
        {
            NHibernateUtil.Initialize(entidade);
        }

        public Boolean IsDirtyEntity(Object entity)
        {
            if (sessao == null)
            {
                throw new ArgumentNullException("session");
            }
            String className = NHibernateProxyHelper.GuessClass(entity).FullName;
            ISessionImplementor sessionImpl = sessao.GetSessionImplementation();
            IEntityPersister persister = sessionImpl.Factory.GetEntityPersister(className);
            EntityEntry oldEntry = sessionImpl.PersistenceContext.GetEntry(sessionImpl.PersistenceContext.Unproxy(entity));
            Object[] oldState = oldEntry.LoadedState;
            Object[] currentState = persister.GetPropertyValues(entity, sessionImpl.EntityMode);
            Int32[] dirtyProps = persister.FindDirty(currentState, oldState, entity, sessionImpl);
            return (dirtyProps != null);
        }

        public TEspecializado InicializarLazyLoad<TEspecializado>(object paraInicializar)
        {
            if (null == paraInicializar)
                throw new ArgumentNullException("paraInicializar");

            if (typeof(TEspecializado) == paraInicializar.GetType())
                return (TEspecializado)paraInicializar;

            if (false == typeof(INHibernateProxy).IsAssignableFrom(paraInicializar.GetType()))
                throw new Exception(string.Format("{0} nao implementa INHibernateProxy", paraInicializar.GetType().FullName));

            ILazyInitializer lazyInitializer = ((INHibernateProxy)paraInicializar).HibernateLazyInitializer;

            return (TEspecializado)lazyInitializer.GetImplementation();
        }


        #region Membros de ITransacaoRepositorio

        public void BeginTransaction()
        {
            transaction = sessao.BeginTransaction();
        }

        public void CommitTransaction()
        {
            // transaction will be replaced with a new transaction
            // by NHibernate, but we will close to keep a consistent state.
            transaction.Commit();

            CloseTransaction();
        }

        public void RollbackTransaction()
        {
            // sessao must be closed and disposed after a transaction
            // rollback to keep a consistent state.
            transaction.Rollback();

            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction()
        {
            transaction.Dispose();
            transaction = null;
        }

        private void CloseSession()
        {
            sessao.Close();
            sessao.Dispose();
        }

        #endregion

        public IList<T> PesquisarAtivos()
        {
            return sessao.CreateCriteria(typeof(T)).Add(Restrictions.Eq("Ativo", true)).List<T>();
        }
    }
}