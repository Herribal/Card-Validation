using Card.Validation.Core.DataAccess.Repository;
using Card.Validation.Web.App.DataAccess.Repository.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Card.Validation.Web.App.DataAccess.RepositoryUow.DB
{
    public class DBRepositoryUow : RepositoryUowBase, IDBRepositoryUow
    {
        private IDBRepository _dbRepository;

        public DBRepositoryUow(string connString = null) 
            : base(connString)
        { }

        public DBRepositoryUow(string connString = null, IsolationLevel isoLevel = IsolationLevel.ReadCommitted)
            : base(connString, isoLevel)
        { }

        public IDBRepository DBRepository =>
            _dbRepository ?? (_dbRepository = new DBRepository(Transaction));

        protected override void ResetRepositories()
        {
            _dbRepository = null;
        }
    }
}