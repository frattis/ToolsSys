using System.Data;
using RDev.ToolsSys.Business.Help;
using RDev.ToolsSys.Business.Pessoas.Entidade;

namespace RDev.ToolsSys.DataAccess.Repositorio
{
    class ClienteRepositorio : ConnectionRepo
    {
        public void SalvarPessoa(Pessoa pessoa)
        {
            AdicionarParametro("@Nome", DbType.String, pessoa.Nome);
            AdicionarParametro("@Cpf", DbType.String, pessoa.ObterDocumentoCpfCnpj().Numero);
            AdicionarParametro("@DatNasc", DbType.String, pessoa.Nascimento);

            var retorno = ExecutarScalar("dbo.proc_Insert_Pessoa");

            if (retorno != null)
                throw new RegraNegocioException(retorno.ToString());
        }
    }
}
