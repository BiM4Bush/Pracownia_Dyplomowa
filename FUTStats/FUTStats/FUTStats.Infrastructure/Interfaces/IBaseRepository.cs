using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUTStats.Infrastructure.Interfaces
{
    public interface IBaseRepository<out T>
    {
        IQueryable<T> FindAll(); 
    }
}
