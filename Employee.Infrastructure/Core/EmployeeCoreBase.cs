using System;
using System.Collections.Generic;
using System.Text;
using Employee.Core.Interfaces;

namespace Employee.Infrastructure.Core
{
    public class EmployeeCoreBase<T> : ICoreBase<T>
    {
        IAppLogger<T> _logger;
        public IAppLogger<T> Logger => _logger;

        public EmployeeCoreBase(IAppLogger<T> appLogger)
        {
            _logger = appLogger;
        }
    }
}
