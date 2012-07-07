using System.Linq;
using System.Text;
using NHibernate;
using RDev.ToolsSys.Business.Pessoas.Entidade;
using RDev.ToolsSys.Business.Pessoas.Repositorio;

namespace RDev.ToolsSys.DataAccess.Nhibernate.Repositorio.Pessoas
{
    public class PessoaRepositorio : NhRepo<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(ISession sessao) : base(sessao) { }

        public Pessoa PesquisarPessoa(string nome)
        {
            var hql = new StringBuilder();

            hql.Append("SELECT pessoa FROM Pessoa pessoa WHERE pessoa.Nome LIKE :nomePessoa");

            var pessoa = sessao.CreateQuery(hql.ToString()).
                 SetParameter("nomePessoa", nome).
                 List<Pessoa>();

            return pessoa.FirstOrDefault();
        }
    }
}
