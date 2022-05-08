using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Domain.Repositories.Entities
{
    public interface IEntitiesRepository<T> : IRepository<T> where T : class
    {

    }
}
