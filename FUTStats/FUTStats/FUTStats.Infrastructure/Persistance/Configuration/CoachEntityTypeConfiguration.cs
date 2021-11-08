using FUTStats.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Configuration
{
    public class CoachEntityTypeConfiguration : IEntityTypeConfiguration<CoachEntity>
    {
        public void Configure(EntityTypeBuilder<CoachEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Nationality).IsRequired();
        }
    }
}
