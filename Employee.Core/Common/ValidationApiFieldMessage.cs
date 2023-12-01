using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Common
{
    public class ValidationApiFieldMessage
    {
        public ValidationApiFieldMessage() {
            Field = string.Empty;
            Message = string.Empty;
        }

        public string Field { get; set; }

        public string Message { get; set; }
    }
}
