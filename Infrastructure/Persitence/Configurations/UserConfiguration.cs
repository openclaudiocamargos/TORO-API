using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persitence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Login)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(t => t.Login)
                .IsUnique();

            builder.Property(t => t.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(t => t.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(t => t.Document)
                .IsUnique();

            builder.Property(t => t.Document)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(t => t.RowVersion)
                .IsRowVersion();
        }
    }
}
