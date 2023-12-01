﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Core.Interfaces
{
    /// <summary>
    /// This type eliminates the need to depend directly on the ASP.NET Core logging types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
       
    }
}
