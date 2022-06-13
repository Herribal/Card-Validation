using Card.Validation.Core.Attributes;
using Card.Validation.Core.Domain;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Card.Validation.Core.DataAccess.Repository
{
    public abstract class RepositoryBase
    {
        protected IDbTransaction Transaction { get; }
        protected IDbConnection Connection => Transaction.Connection;

        protected RepositoryBase(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        public static string GenerateMySqlInsertQuery<T>(string overrideTablename)
            where T : IDomainModel
        {
            var type = typeof(T);

            var table = (string.IsNullOrWhiteSpace(overrideTablename))
                ? type.GetCustomAttribute<TableAttribute>()?.Name ?? type.Name
                : overrideTablename;

            var columns = type.GetProperties()
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null)
                .Select(p => p.GetCustomAttribute<ColumnAttribute>()?.Name ?? p.Name);

            var properties = type.GetProperties()
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null)
                .Select(p => p.Name);

            return $@"INSERT INTO `{table}` (`{string.Join("`, `", columns)}`) VALUES (@{string.Join(", @", properties)});";
        }
    }
}
