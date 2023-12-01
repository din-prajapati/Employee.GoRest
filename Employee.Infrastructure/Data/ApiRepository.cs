using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Employee.Infrastructure.Data;
using Employee.Core.Entities;
using Employee.Core.Interfaces;
using Employee.Core;
using System.Net.Http;
using System.Net;
using Employee.Core.Common;

namespace Employee.Infrastructure.Data
{
    public class ApiRepository<T> : IApiRepository<T> where T : BaseEntity
    {
        private readonly HttpClient _client;
        private readonly string _resource;

        public ApiRepository(HttpClient client, string resource)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
            _resource = resource;
        }

        public async Task<ApiEntityListResponse<T>> GetAllAsync()
        {
            return await ApiHelper.GetList<T>(_client, _resource);
        }

        public async Task<ApiEntityResponse<T>> GetAsync(long id)
        {
            return await ApiHelper.Get<T>(_client, _resource + "/" + id);
        }

        public async Task<ApiEntityListResponse<T>> GetAllAsync(int page)
        {
            ApiEntityListResponse<T> mListResponse = await ApiHelper.GetList<T>(_client, _resource + "?page=" + page);
            if (mListResponse != null && mListResponse.Entities == null)
            {
                if (page > mListResponse.TotalPages)
                {
                    mListResponse = await ApiHelper.GetList<T>(_client, _resource + "/" + mListResponse.TotalPages);
                }
            }
            return mListResponse;
        }

        public async Task<ApiEntityListResponse<T>> GetAllAsync(string name)
        {
            return await ApiHelper.GetList<T>(_client, _resource + "?name=" + name);
        }

        public async Task<ApiEntityResponse<T>> Add(T entity)
        {
            return await ApiHelper.Post<T>(_client, _resource, entity);
        }

        public async Task<ApiEntityResponse<T>> Update(long id, T entity)
        {
            return await ApiHelper.Put<T>(_client, _resource + "/" + id, entity);
        }

        public async Task<HttpStatusCode> Delete(long id)
        {
            return await ApiHelper.Delete(_client, _resource + "/" + id);
        }
    }
}
