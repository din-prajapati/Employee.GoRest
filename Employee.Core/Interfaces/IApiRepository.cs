using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Employee.Core.Common;
using Employee.Core.Entities;

namespace Employee.Core.Interfaces
{
    public interface IApiRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets all Records.
        /// </summary>
        /// <returns>List of entities</returns>
        Task<ApiEntityListResponse<T>> GetAllAsync();


        /// <summary>
        /// Gets Record details by id.
        /// </summary>
        /// <returns>List of entities</returns>
        Task<ApiEntityResponse<T>> GetAsync(long id);


        /// <summary>
        /// Gets all Records.. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<ApiEntityListResponse<T>> GetAllAsync(int page);

        /// <summary>
        /// Gets all Records which contains specific name
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        Task<ApiEntityListResponse<T>> GetAllAsync(string name);

        /// <summary>
        /// Used to Add Record
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        Task<ApiEntityResponse<T>> Add(T Entity);

        /// <summary>
        /// Used to update Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        Task<ApiEntityResponse<T>> Update(long id, T entity);

        /// <summary>
        /// Used to delete record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HttpStatusCode> Delete(long id);
    }
}
