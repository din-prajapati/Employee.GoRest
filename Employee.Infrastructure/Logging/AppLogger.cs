using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Employee.Core.Interfaces;

namespace Employee.Infrastructure.Logging
{
    public class AppLogger<T> : IAppLogger<T>
    {
        private Type _loggerType = typeof(T);
        private string _loggerName = typeof(T).ToString();
        
        public AppLogger()
        {

        }
        
    }
}
