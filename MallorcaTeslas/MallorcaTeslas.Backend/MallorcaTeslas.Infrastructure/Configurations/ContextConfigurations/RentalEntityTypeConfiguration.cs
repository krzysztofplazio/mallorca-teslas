using MallorcaTeslas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Configurations.ContextConfigurations;

public class RentalEntityTypeConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseIdentityColumn();

        builder.Property(e => e.TotalPrice)
           .HasPrecision(14, 2)
           .IsRequired();

        builder.HasOne(r => r.BorrowPlace)
            .WithMany(bp => bp.Borrows)
            .HasForeignKey(r => r.BorrowPlaceId);

        builder.HasOne(r => r.ReturnPlace)
            .WithMany(rp => rp.Returns)
            .HasForeignKey(r => r.ReturnPlaceId);

        builder.HasOne(r => r.Car)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CarId);
    }
}
