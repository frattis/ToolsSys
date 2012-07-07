using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

/*
 * Este arquivo Contém as classes que herdam de System.Exception, portanto são 
 * uma exceção personalizada. São execeções disparadas pelas classes que 
 * implemetam regras de negócio e que a visualização irá tratar com um CATCH
  */
namespace RDev.ToolsSys.Business.Help
{
    [Serializable]
    public class RegraNegocioException : Exception
    {

        public RegraNegocioException()
        {
        }

        public RegraNegocioException(string message)
            : base(message)
        {
        }

        public RegraNegocioException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    [Serializable]
    public class CamposObrigatoriosNaoPreenchidosException : Exception
    {
        public Dictionary<string, string> campos { get; set; }

        public CamposObrigatoriosNaoPreenchidosException(string message, Dictionary<string, string> campos)
            : base(message)
        {
            this.campos = campos;
        }

        public CamposObrigatoriosNaoPreenchidosException(string message, Exception inner, Dictionary<string, string> campos)
            : base(message, inner)
        {
            this.campos = campos;
        }
    }
}
