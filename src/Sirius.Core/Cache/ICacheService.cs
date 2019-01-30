using System;
using System.Collections.Generic;
using System.Text; 
using Microsoft.EntityFrameworkCore;

namespace Sirius.Core.Cache
{
    public interface ICacheService 
    {
        string GetKey<T>();
        void Remove<T>();
        List<T> GetOrAdd<T>(Func<List<T>> factory);
    }
}
