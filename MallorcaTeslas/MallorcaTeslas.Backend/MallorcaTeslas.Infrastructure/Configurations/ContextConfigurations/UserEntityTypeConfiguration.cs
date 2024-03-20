using MallorcaTeslas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Configurations.ContextConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Username)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(e => e.Password)
            .HasMaxLength(128)
            .IsRequired();
    }
}
