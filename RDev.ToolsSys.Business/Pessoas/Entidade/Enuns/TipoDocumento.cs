using System.ComponentModel;

namespace RDev.ToolsSys.Business.Pessoas.Entidade.Enuns
{
    public enum TipoDocumento
    {
        [Description("RG")]
        RG = 1,

        [Description("CPF")]
        CPF = 2,

        [Description("IE")]
        IE = 3,

        [Description("CNPJ")]
        CNPJ = 4
    }
}