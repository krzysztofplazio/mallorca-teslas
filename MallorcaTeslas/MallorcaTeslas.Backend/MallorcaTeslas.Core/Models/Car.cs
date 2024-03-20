using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Models;

public class Car
{
    public int Id { get; set; }
    public string Mark { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int ChargingMinutes { get; set; }
    public int Power { get; set; }
    public int ProductionYear { get; set; }
    public decimal PricePerDay { get; set; }
    public decimal PricePerMonth { get; set; }
    public string Currency { get; set; } = null!;
    public int RangeLimit { get; set; }
    public int RentDays { get; set; }
    public ICollection<Rental> Rentals { get; set; } = [];
}
