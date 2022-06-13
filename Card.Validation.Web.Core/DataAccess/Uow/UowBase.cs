using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Validation.Web.Core.DataAccess.Repository
{
    public abstract class UowBase
    {
        private bool _disposed;
        private readonly IsolationLevel _isoLevel;

        protected IDbTransaction Transaction;
        protected IDbConnection Connection;

        protected UowBase(string connString, IsolationLevel isoLevel = IsolationLevel.ReadCommitted)
        {
            Connection = new SqlConnection(connString);

            Connection.Open();

            Transaction = Connection.BeginTransaction(isoLevel);
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
                Transaction = Connection.BeginTransaction(_isoLevel);
            }
        }

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

                Connection?.Dispose();
                Connection = null;
            }

            _disposed = true;
        }

        ~UowBase()
        {
            Dispose(false);
        }
    }
}
