using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Models;

public class Rental
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int BorrowPlaceId { get; set; }
    public int ReturnPlaceId { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public Customer Customer { get; set; } = null!;
    public Place BorrowPlace { get; set; } = null!;
    public Place ReturnPlace { get; set; } = null!;
    public Car Car { get; set; } = null!;
}
