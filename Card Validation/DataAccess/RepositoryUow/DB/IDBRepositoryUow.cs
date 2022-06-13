using Card.Validation.Core.DataAccess.Repository;
using Card.Validation.Web.App.DataAccess.Repository.DB;

namespace Card.Validation.Web.App.DataAccess.RepositoryUow.DB
{
    public interface IDBRepositoryUow : IUow
    {
        IDBRepository DBRepository { get; }
    }
}
