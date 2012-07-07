using System.ComponentModel;

namespace RDev.ToolsSys.Business.Pessoas.Entidade.Enuns
{
    public enum TipoContato
    {
        [Description("Residencial")]
        RESIDENCIAL = 1,

        [Description("Comercial")]
        COMERCIAL = 2,

        [Description("Celular")]
        CELULAR = 3,

        [Description("Fax")]
        FAX = 4,

        [Description("Email")]
        EMAIL = 5
    }
}