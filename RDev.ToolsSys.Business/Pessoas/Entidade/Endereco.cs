using RDev.ToolsSys.Business.Pessoas.Entidade.Enuns;

namespace RDev.ToolsSys.Business.Pessoas.Entidade
{
    public class Endereco
    {
        #region Atributos Privados
        private string cep;
        private TipoEndereco tipoEndereco;
        private string logradouro;
        private string bairro;
        private string numero;
        private string estado;
        private string cidade;
        #endregion

        #region Propriedades
        public string Cep { get { return cep; } set { cep = value; } }
        public TipoEndereco TipoEndereco { get { return tipoEndereco; } set { tipoEndereco = value; } }
        public string Logradouro { get { return logradouro; } set { logradouro = value; } }
        public string Bairro { get { return bairro; } set { bairro = value; } }
        public string Numero { get { return numero; } set { numero = value; } }
        public string Estado { get { return estado; } set { estado = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }
        #endregion

        #region Helpers
        internal Endereco PesquisarEnderecoPorCep(string pCep)
        {
            return PesquisarEnderecoPorCep(pCep);
        }
        #endregion
    }
}

