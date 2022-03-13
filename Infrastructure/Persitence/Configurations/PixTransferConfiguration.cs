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
    public class PixTransferConfiguration : IEntityTypeConfiguration<PixTransfer>
    {
        public void Configure(EntityTypeBuilder<PixTransfer> builder)
        {
            builder.Property(t => t.AccountOrigin)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
