using FUTStats.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.DbContexts
{
    public class FutStatsDbContext: DbContext
    {
        public FutStatsDbContext(DbContextOptions<FutStatsDbContext> options): base(options)
        {

        }
        public DbSet<PlayerEntity> Player { get; set; }
        public DbSet<StatisticEntity> Statistic { get; set; }
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<CoachEntity> Coach { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FutStatsDbContext).Assembly);
        }
    }
}
