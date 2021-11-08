using FUTStats.Infrastructure.Secuirity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Secuirity.Configuration
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        private readonly RoleEntity[] roles = new RoleEntity[]
        {
            new RoleEntity { Id = 1, Name = "Administrator"},
            new RoleEntity { Id = 2, Name = "User"},
            new RoleEntity { Id = 3, Name = "Guest"},
        };
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasData(roles);

        }
    }
}
