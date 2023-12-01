using Employee.Core.Common;
using System;
using System.Text.Json.Serialization;

namespace Employee.Core
{
    public class BaseEntity
    {
        [JsonIgnore]
        public List<ValidationApiFieldMessage> ValidationFieldMessage { get; set; }
    }
}
