using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Service.Models
{
    public class EmployeeListItem
    {
        public List<EmployeeEntity>? Entities { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
