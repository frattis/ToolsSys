using System;
using System.Collections.Generic;
using System.Linq;
using RDev.ToolsSys.Business.Help;
using RDev.ToolsSys.Business.Pessoas.Entidade.Enuns;

namespace RDev.ToolsSys.Business.Pessoas.Entidade
{
    public class Pessoa
    {
        public Pessoa()
        {
            Documentos = new List<Documento>();
            Enderecos = new List<Endereco>();
            Contatos = new List<Contato>();
        }

        #region Atributos Privados
        private int id;
        private string nome;
        private DateTime nascimento;
        private DateTime cadastrado;
        private List<Documento> documentos;
        private List<Endereco> enderecos;
        private List<Contato> contatos;
        private TipoSexo tipoSexo;
        private TipoEstadoCivil tipoEstadoCivil;
        private TipoPessoa tipoPessoa;
        #endregion

        #region Propriedades
        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }

        public DateTime Nascimento
        {
            get { return nascimento; }
            set
            {
                if (!FuncoesGerais.ValidarData(value.ToString())) throw new RegraNegocioException("Data de Nascimento Invalida.");
                nascimento = value;
            }
        }
        public DateTime Cadastrado { get { return cadastrado; } set { cadastrado = value; } }

        public TipoSexo TipoSexo { get { return tipoSexo; } set { tipoSexo = value; } }
        public TipoPessoa TipoPessoa { get { return tipoPessoa; } set { tipoPessoa = value; } }
        public TipoEstadoCivil TipoEstadoCivil { get { return tipoEstadoCivil; } set { tipoEstadoCivil = value; } }

        public List<Documento> Documentos { get { return documentos; } set { documentos = value; } }
        public List<Endereco> Enderecos { get { return enderecos; } set { enderecos = value; } }
        public List<Contato> Contatos { get { return contatos; } set { contatos = value; } }
        #endregion

        #region Helpers
        public void ValidarDados()
        {
            var campos = new Dictionary<string, string>();


            if (string.IsNullOrEmpty(Nome)) campos.Add("* Nome", "");
            var cpfCnpj = Documentos.FirstOrDefault(x => x.TipoDocumento == TipoDocumento.CNPJ || x.TipoDocumento == TipoDocumento.CPF);
            if (cpfCnpj != null && string.IsNullOrEmpty(cpfCnpj.Numero.Replace(".", "").Replace("-", ""))) campos.Add("* CPF", "");
            if (string.IsNullOrEmpty(Nascimento.ToString().Replace("/", ""))) campos.Add("* Nascimento", "");

            if (campos.Count > 0) throw new CamposObrigatoriosNaoPreenchidosException("Campos Obrigatórios : ", campos);
        }

        public Documento ObterDocumentoCpfCnpj()
        {
            if (Documentos == null || Documentos.Count <= 0)
            {
                return null;
            }

            return Documentos.FirstOrDefault(x => x.TipoDocumento == TipoDocumento.CNPJ || x.TipoDocumento == TipoDocumento.CPF);
        }

        public Endereco ObterEndereco()
        {
            if (this.Enderecos == null || this.Enderecos.Count <= 0)
                return null;

            var endereco = this.Enderecos.
                FirstOrDefault(x => x.TipoEndereco == TipoEndereco.RESIDENCIAL || x.TipoEndereco == TipoEndereco.COMERCIAL);

            return endereco;
        }

        public Contato ObterTelefone()
        {
            if (this.Contatos == null || this.Contatos.Count <= 0)
                return null;

            var telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.RESIDENCIAL);
            if (telefone.IsNull()) telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.COMERCIAL);
            if (telefone.IsNull()) telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.CELULAR);
            if (telefone.IsNull()) telefone = Contatos.FirstOrDefault(x => x.TipoContato == TipoContato.FAX);

            return telefone;
        }
        #endregion
    }
}
