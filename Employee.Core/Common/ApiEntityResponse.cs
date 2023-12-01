using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Common
{
    public class ApiEntityResponse<TEntity> where TEntity : BaseEntity
    {
        public ApiEntityResponse(TEntity entity)
        {
            Entity = entity;
        }

        public ApiEntityResponse(TEntity entity, HttpStatusCode statusCode)
        {
            Entity = entity;
            StatusCode = statusCode;
        }

        public ApiEntityResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public TEntity Entity;

        public HttpStatusCode StatusCode { get; set; }
    }
}
