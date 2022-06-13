using System;

namespace Card.Validation.Core.DataAccess.Repository
{
    public interface IUow : IDisposable
    {
        void Commit(); 
    }
}
