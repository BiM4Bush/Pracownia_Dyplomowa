using FUTStats.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Configuration
{
    public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<PlayerEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity> builder)
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


        }
    }
}
