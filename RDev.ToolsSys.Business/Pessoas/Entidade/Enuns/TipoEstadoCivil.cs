using System;
using System.ComponentModel;

namespace RDev.ToolsSys.Business.Pessoas.Entidade.Enuns
{
    [Flags]
    public enum TipoEstadoCivil
    {
        [Description("Casado")]
        CASADO = 1,

        [Description("Solteiro")]
        SOLTEIRO = 2,

        [Description("Viuvo")]
        VIUVO = 3,

        [Description("Outros")]
        OUTROS = 4,
    }
}
