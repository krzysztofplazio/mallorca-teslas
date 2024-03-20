using MallorcaTeslas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Configurations.ContextConfigurations;

public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.Mark)
            .HasMaxLength(10)
            .IsRequired();
        
        builder.Property(e => e.Model)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.PricePerDay)
            .HasPrecision(14, 2)
            .IsRequired();
        
        builder.Property(e => e.PricePerMonth)
            .HasPrecision(14, 2)
            .IsRequired();
        
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .IsRequired();
    }
}
