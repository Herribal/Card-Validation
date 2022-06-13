using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Validation.Web.Core.DataAccess.Repository
{
    public abstract class RepositoryUowBase : IUow
    {

        private bool _disposed;                                      
        private IDbConnection _connection;
        private readonly IsolationLevel _isoLevel;

        protected IDbTransaction Transaction;

        protected RepositoryUowBase(string connString, IsolationLevel isoLevel = IsolationLevel.ReadCommitted)
        {
            _connection = new SqlConnection(connString);

            _connection.Open();

            Transaction = _connection.BeginTransaction(isoLevel);
        }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
            finally
            {
                Transaction.Dispose();
                Transaction = _connection.BeginTransaction(_isoLevel);
                ResetRepositories();
            }
        }

        protected abstract void ResetRepositories();

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Transaction?.Dispose();
                Transaction = null;

                _connection?.Dispose();
                _connection = null;
            }

            _disposed = true;
        }

        ~RepositoryUowBase()
        {
            Dispose(false);
        }
    }
}
