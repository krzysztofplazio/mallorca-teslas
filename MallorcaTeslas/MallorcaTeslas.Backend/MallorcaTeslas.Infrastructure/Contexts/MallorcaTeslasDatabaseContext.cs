using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Infrastructure.Configurations.ContextConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Contexts;

public class MallorcaTeslasDatabaseContext(DbContextOptions<MallorcaTeslasDatabaseContext> options) : DbContext(options)
{
    public virtual DbSet<Car> Cars { get; set; } = null!;
    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Place> Places { get; set; } = null!;
    public virtual DbSet<Rental> Rentals { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CarEntityTypeConfiguration().Configure(modelBuilder.Entity<Car>());
        new CustomerEntityTypeConfiguration().Configure(modelBuilder.Entity<Customer>());
        new PlaceEntityTypeConfiguration().Configure(modelBuilder.Entity<Place>());
        new RentalEntityTypeConfiguration().Configure(modelBuilder.Entity<Rental>());
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
    }
}
