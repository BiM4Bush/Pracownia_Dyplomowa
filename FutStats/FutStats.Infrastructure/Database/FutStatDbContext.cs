using FutStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Infrastructure.Database
{
    public class FutStatDbContext : DbContext
    {
        public FutStatDbContext(DbContextOptions<FutStatDbContext> options) : base(options)
        {

        }
        
        public DbSet<PlayerEntity> Player { get; set; }
        
        public DbSet<StatisticEntity> Statistic { get; set; }
        
        public DbSet<TeamEntity> Team { get; set; }
        
        public DbSet<CoachEntity> Coach { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoachEntity>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
                builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
                builder.Property(x => x.Nationality).IsRequired();
            }
            );

            modelBuilder.Entity<PlayerEntity>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
                builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
                builder.Property(x => x.KitNumber).IsRequired();
                builder.Property(x => x.Position).IsRequired();

                builder
                    .HasOne<StatisticEntity>()
                    .WithOne(x => x.Player)
                    .HasForeignKey<StatisticEntity>(x => x.PlayerId);
            });

            modelBuilder.Entity<StatisticEntity>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.Goals).IsRequired();
                builder.Property(x => x.Assists).IsRequired();
                builder.Property(x => x.YellowCards).IsRequired();
                builder.Property(x => x.RedCards).IsRequired();
            });

            modelBuilder.Entity<TeamEntity>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
                builder.Property(x => x.Id).IsRequired();

                builder
                    .HasMany<PlayerEntity>(x => x.Players)
                    .WithOne(x => x.Team)
                    .HasForeignKey(x => x.TeamId);

                builder
                    .HasOne<CoachEntity>()
                    .WithOne(x => x.Team)
                    .HasForeignKey<CoachEntity>(x => x.TeamId);
            });
        }


    }
}
