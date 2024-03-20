using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Models;

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Rental> Rentals { get; set; } = [];
}
