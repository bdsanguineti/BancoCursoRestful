using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration
{
    public class ClienteConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.BirthDate)                
                .IsRequired();

            builder.Property(p => p.Telephone)
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(100);

            builder.Property(p => p.Address)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(p => p.Age);

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(30);

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}
