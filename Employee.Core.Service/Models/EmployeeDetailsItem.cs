using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.Core.Service.Models
{
    public class EmployeeDetailsItem
    {
        public EmployeeDetailsItem()
        {
            Entity = new EmployeeEntity();
        }

        public EmployeeEntity? Entity { get; set; }             
    }
}
