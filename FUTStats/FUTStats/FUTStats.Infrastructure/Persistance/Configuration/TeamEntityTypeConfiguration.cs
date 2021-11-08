using FUTStats.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Configuration
{
    public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<PlayerEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<PlayerEntity>(x => x.TeamId);

            builder
                .HasOne<CoachEntity>()
                .WithOne(x => x.Team)
                .HasForeignKey<CoachEntity>(x => x.TeamId);
        }
    }
}
