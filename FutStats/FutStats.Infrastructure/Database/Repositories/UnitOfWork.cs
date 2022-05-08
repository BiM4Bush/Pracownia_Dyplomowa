using FutStats.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FutStats.Infrastructure.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FutStatDbContext _dbContext;

        public UnitOfWork(FutStatDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task Complete(CancellationToken cancellacionToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellacionToken);
        }
    }
}
