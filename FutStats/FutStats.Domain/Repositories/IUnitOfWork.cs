using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutStats.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Complete(CancellationToken cancellacionToken = default);
    }
}
