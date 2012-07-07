namespace RDev.ToolsSys.Business.BaseRepositorio
{
    public interface ITransacaoRepositorio
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
