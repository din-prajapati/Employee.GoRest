using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Employee.Core.Entities;
using Employee.Core.Interfaces;

namespace Employee.Core.Interfaces
{
    public interface IApiRepositoryFactory : IDisposable
    {
        IApiRepository<TEntity> GetRepository<TEntity>(HttpClient client, string resource) where TEntity : BaseEntity;

    }       
}
