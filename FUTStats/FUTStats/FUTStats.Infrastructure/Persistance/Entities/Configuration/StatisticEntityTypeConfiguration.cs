using FUTStats.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Configuration
{
    public class StatisticEntityTypeConfiguration : IEntityTypeConfiguration<StatisticEntity>
    {
        public void Configure(EntityTypeBuilder<StatisticEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Goals).IsRequired();
            builder.Property(x => x.Assists).IsRequired();
            builder.Property(x => x.YellowCards).IsRequired();
            builder.Property(x => x.RedCards).IsRequired();
        }
    }
}
