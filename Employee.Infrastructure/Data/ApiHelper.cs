using Employee.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Employee.Core.Common;
using Employee.Core;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Employee.Infrastructure.Data
{
    public static class ApiHelper
    {
        public static async Task<ApiEntityListResponse<T>> GetList<T>(HttpClient client, string requestUri) where T : BaseEntity
        {
            using HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<List<T>>();
                ApiEntityListResponse<T> apiEntityListResponse = new ApiEntityListResponse<T>(model, response.StatusCode);

                
                //x-pagination-total
                string totalHeaderCount = GetHeader(response, "x-pagination-total");
                apiEntityListResponse.TotalCount = Convert.ToInt16((!string.IsNullOrEmpty(totalHeaderCount) ? totalHeaderCount : 0 ));

                //x-pagination-page
                string currentPage = GetHeader(response, "x-pagination-page");
                apiEntityListResponse.CurrentPage = Convert.ToInt16((!string.IsNullOrEmpty(currentPage) ? currentPage : 0));

                //x-pagination-pages
                string totalPages = GetHeader(response, "x-pagination-pages");
                apiEntityListResponse.TotalPages = Convert.ToInt16((!string.IsNullOrEmpty(totalPages) ? totalPages : 0));

                return apiEntityListResponse;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        private static string GetHeader(HttpResponseMessage response, string header)
        {
            IEnumerable<string> values;
            if (response.Headers.TryGetValues(header, out values))
            {
                return values != null ? values.FirstOrDefault() : string.Empty;
            }

            return string.Empty;
        }

        public static async Task<ApiEntityResponse<T>> Get<T>(HttpClient client, string requestUri) where T : BaseEntity
        {
            using HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<T>();
                ApiEntityResponse<T> apiEntityResponse = new ApiEntityResponse<T>(model, response.StatusCode);
                return apiEntityResponse;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<ApiEntityResponse<T>> Post<T>(HttpClient client, string requestUri, T content) where T : BaseEntity
        {   
            using HttpResponseMessage response = await client.PostAsync(requestUri, JsonContent.Create(content));
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<T>();
                ApiEntityResponse<T> apiEntityResponse = new ApiEntityResponse<T>(model, response.StatusCode);
                return apiEntityResponse;
            }
            else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var apiValidationResponses = await response.Content.ReadAsAsync<List<ValidationApiFieldMessage>>();
                content.ValidationFieldMessage = apiValidationResponses;
                ApiEntityResponse<T> apiEntityResponse = new ApiEntityResponse<T>(content, response.StatusCode);
                return apiEntityResponse;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<ApiEntityResponse<T>> Put<T>(HttpClient client, string requestUri, T content) where T : BaseEntity
        {
            using HttpResponseMessage response = await client.PutAsync(requestUri, JsonContent.Create(content));            
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<T>();
                ApiEntityResponse<T> apiEntityResponse = new ApiEntityResponse<T>(model, response.StatusCode);
                return apiEntityResponse;
            }
            else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var apiValidationResponses = await response.Content.ReadAsAsync<List<ValidationApiFieldMessage>>();
                content.ValidationFieldMessage = apiValidationResponses;
                ApiEntityResponse<T> apiEntityResponse = new ApiEntityResponse<T>(content, response.StatusCode);
                return apiEntityResponse;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<HttpStatusCode> Delete(HttpClient client, string requestUri)
        {
            using HttpResponseMessage response = await client.DeleteAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                return response.StatusCode;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
