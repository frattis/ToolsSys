using System.ComponentModel;

namespace RDev.ToolsSys.Business.Pessoas.Entidade.Enuns
{
    public enum TipoPessoa : int
    {
        [Description("Pessoa Física")]
        FISICA = 1,

        [Description("Pessoa Jurídica")]
        JURIDICA = 2
    }
}