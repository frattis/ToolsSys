using RDev.ToolsSys.Business.Pessoas.Entidade.Enuns;

namespace RDev.ToolsSys.Business.Pessoas.Entidade
{
    public class Contato
    {
        public string Numero { get; set; }
        public TipoContato TipoContato { get; set; }
        public string Email { get; set; }
    }
}
