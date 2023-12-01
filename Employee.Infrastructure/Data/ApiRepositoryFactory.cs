using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Employee.Core.Entities;
using Employee.Core.Interfaces;
using Employee.Core;

namespace Employee.Infrastructure.Data
{
    public class ApiRepositoryFactory: IApiRepositoryFactory        
    {
        /// <summary>
        /// The repositories
        /// </summary>
        private Dictionary<Type, object> _repositories = null;

        public ApiRepositoryFactory()
        {
        }

        public IApiRepository<TEntity> GetRepository<TEntity>(HttpClient client, string resource) where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new ApiRepository<TEntity>(client, resource);
            return (IApiRepository<TEntity>)_repositories[type];
        }
        
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
