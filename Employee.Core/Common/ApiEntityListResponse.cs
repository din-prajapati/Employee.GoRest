using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Common
{
    public class ApiEntityListResponse<TEntity> where TEntity : BaseEntity
    {

        public List<TEntity> Entities { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ApiEntityListResponse(List<TEntity> entities)
        {
            Entities = entities;
        }

        public ApiEntityListResponse(List<TEntity> entities, HttpStatusCode statusCode)
        {
            Entities = entities;
            StatusCode = statusCode;
        }

    }
}
