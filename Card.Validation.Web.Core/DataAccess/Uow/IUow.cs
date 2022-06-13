namespace Card.Validation.Web.Core.DataAccess.Repository
{
    public interface IUow : IDisposable
    {
        void Commit(); 
    }
}
