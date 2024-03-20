using MallorcaTeslas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Configurations.ContextConfigurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.FullName)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(e => e.Address)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Country)
            .HasMaxLength(25)
            .IsRequired();
        
        builder.Property(e => e.Phone)
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasOne(c => c.User)
            .WithOne(u => u.Customer)
            .HasForeignKey<Customer>(c => c.UserId);

        builder.HasMany(c => c.Rentals)
            .WithOne(r => r.Customer)
            .HasForeignKey(r => r.CustomerId);
    }
}
