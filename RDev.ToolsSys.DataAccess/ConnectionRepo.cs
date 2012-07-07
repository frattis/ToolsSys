using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RDev.ToolsSys.DataAccess
{
    public abstract class ConnectionRepo
    {
        private Database MyDatabase { get; set; }
        private DbCommand MyCommand { get; set; }
        private DbTransaction Transacao { get; set; }
        private DbConnection Conexao { get; set; }
        public static bool UsarTransacao { get; set; }

        private static bool _usarException = true;
        public bool UsarException
        {
            get { return _usarException; }
            set { _usarException = value; }
        }
        private List<Parametro> Parametros { get; set; }

        protected ConnectionRepo(string connectionName)
        {
            MyDatabase = string.IsNullOrEmpty(connectionName) ? DatabaseFactory.CreateDatabase() : DatabaseFactory.CreateDatabase(connectionName);
        }

        protected ConnectionRepo()
        {
            MyDatabase = DatabaseFactory.CreateDatabase();
        }


        protected void ExcluirParametros()
        {
            Parametros = new List<Parametro>();
        }



        protected void AdicionarParametro(string nomeParametro, DbType tipo, object valor)
        {
            Parametros = Parametros ?? new List<Parametro>();
            Parametros.Add(new Parametro() { NomeParametro = nomeParametro, Tipo = tipo, Valor = valor });
        }

        /// <summary>
        /// Passar para um script uma lista de parametros. Baseado no NHibernate.ISession.IQuery.SetParameterList
        /// </summary>
        /// <param name="prefixoParametros">nome dos parametros quer serao criados.</param>
        /// <param name="dbType">Tipo dos parametros que serao criados</param>
        /// <param name="listaValoresParametros">lista com os valores dos parametros</param>
        /// <returns>Nomes dos parametros separados por ",", para ser utilizado em scripts</returns>
        /// <example>
        /// var chassis = new List&lt;string&gt;{ "C4300001", "C4300002", "C4300003", "C4300004" };
        /// var nomeParametroLista = this.AdicionarParametroLista("@nroChassiFim", DbType.AnsiString, chassis);
        /// var script = "SELECT * FROM tbVeiculo WHERE NroChassiFim IN (" + nomeParametroLista + ")";
        /// var reader = this.ExecutarReader(script, CommandType.Text);
        /// </example>
        protected string AdicionarParametroLista<T>(string prefixoParametros, DbType dbType, IList<T> listaValoresParametros)
        {
            if (listaValoresParametros == null || listaValoresParametros.Count <= 0) return null;

            if (listaValoresParametros.Count > 2100)
            {
                // FIXME: ExecuteReader chamara a procedure execute_sql. Se houver mais de 2100 parametros, a procedure ocorre erro.
                // FIXME: listar os valores diretamente previne este erro, mas não é o recomendado.
                // FIXME: Feito desta forma porque aqui o que prevalece é o performance.
                return String.Join(", ", listaValoresParametros);
            }

            var nomesParametros = new List<string>();
            for (int i = 0; i < listaValoresParametros.Count; i++)
            {
                var parameterName = prefixoParametros + i;
                var parameterValue = listaValoresParametros[i];

                this.AdicionarParametro(parameterName, dbType, parameterValue);

                nomesParametros.Add(parameterName);
            }

            return String.Join(", ", nomesParametros);
        }

        protected void LimparParametros()
        {
            Parametros = new List<Parametro>();
        }

        protected void Executar(string command, CommandType commandType)
        {
            try
            {
                Conexao = MyDatabase.CreateConnection();
                Conexao.Open();

                if (UsarTransacao) Transacao = Conexao.BeginTransaction();

                MyCommand = (commandType == CommandType.StoredProcedure) ? MyDatabase.GetStoredProcCommand(command)
                                                                         : MyDatabase.GetSqlStringCommand(command);
                VincularParametros();

                MyCommand.Connection = Conexao;

                MyCommand.ExecuteNonQuery();

                if (UsarTransacao) Transacao.Commit();
            }

            catch (SqlException sq)
            {
                if (UsarTransacao) Transacao.Rollback();
                throw new Exception(sq.Message);
            }
            finally
            {
                if (MyCommand != null) MyCommand.Dispose();
                if (Conexao != null)
                {
                    Conexao.Dispose();
                    Conexao.Close();
                }
            }
        }

        protected object ExecutarScalar(string command)
        {
            try
            {
                Conexao = MyDatabase.CreateConnection();
                Conexao.Open();

                if (UsarTransacao) Transacao = Conexao.BeginTransaction();

                MyCommand = MyDatabase.GetStoredProcCommand(command);
                VincularParametros();

                MyCommand.Connection = Conexao;

                var retorno = MyCommand.ExecuteScalar();

                if (UsarTransacao) Transacao.Commit();

                return retorno;
            }
            catch (Exception e)
            {
                if (UsarTransacao) Transacao.Rollback();

                if (!UsarException)
                    return null;


                throw new Exception(e.Message);
            }
            finally
            {
                if (MyCommand != null) MyCommand.Dispose();
                if (Conexao != null)
                {
                    Conexao.Dispose();
                    Conexao.Close();
                }
            }
        }

        protected DataSet Consultar(string command, CommandType commandType)
        {
            try
            {
                Conexao = MyDatabase.CreateConnection();
                Conexao.Open();

                MyCommand = (commandType == CommandType.StoredProcedure) ? MyDatabase.GetStoredProcCommand(command)
                                                                         : MyDatabase.GetSqlStringCommand(command);
                VincularParametros();

                return MyDatabase.ExecuteDataSet(MyCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (MyCommand != null) MyCommand.Dispose();
                if (Conexao != null)
                {
                    Conexao.Dispose();
                    Conexao.Close();
                }
            }
        }

        protected IDataReader ExecutarReader(string command, CommandType commandType, int timeout = 30)
        {
            try
            {
                Conexao = MyDatabase.CreateConnection();
                Conexao.Open();

                MyCommand = (commandType == CommandType.StoredProcedure) ? MyDatabase.GetStoredProcCommand(command)
                                                                         : MyDatabase.GetSqlStringCommand(command);

                MyCommand.CommandTimeout = timeout;

                VincularParametros();

                return MyDatabase.ExecuteReader(MyCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (MyCommand != null) MyCommand.Dispose();
                if (Conexao != null)
                {
                    Conexao.Dispose();
                    Conexao.Close();
                }
            }
        }

        private void VincularParametros()
        {
            if (Parametros == null) return;
            foreach (var parametro in Parametros) MyDatabase.AddInParameter(MyCommand, parametro.NomeParametro, parametro.Tipo, parametro.Valor);
        }

        protected IList<T> ConverterReaderToIListGeneric<T>(IDataReader reader, Func<IDataReader, T> ObterItemPorReader) where T : class, new()
        {
            if (reader == null)
            {
                return null;
            }

            var lista = new List<T>();

            while (reader.Read())
            {
                lista.Add(ObterItemPorReader(reader));
            }

            return lista;
        }

        protected IEnumerable ConverterReaderToIEnumerable<T>(IDataReader reader, Func<IDataReader, T> ObterItemPorReader) where T : class, new()
        {
            if (reader == null)
            {
                yield return null;
            }

            while (reader.Read())
            {
                yield return ObterItemPorReader(reader);
            }
        }
    }

    public class Parametro : IEnumerable
    {
        public string NomeParametro { get; set; }
        public DbType Tipo { get; set; }
        public object Valor { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
