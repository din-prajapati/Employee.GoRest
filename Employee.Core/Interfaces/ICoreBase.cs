using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Core.Interfaces
{
    /// <summary>
    /// used to define all common Core & Base Depndency injection services.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICoreBase<T>
    {
        IAppLogger<T> Logger { get; }
    }
}
