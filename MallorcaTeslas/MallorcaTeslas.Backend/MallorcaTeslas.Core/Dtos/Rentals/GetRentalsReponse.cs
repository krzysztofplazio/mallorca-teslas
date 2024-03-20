using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Dtos.Rentals;

public class GetRentalsReponse
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string BorrowPlace { get; set; } = null!;
    public string ReturnPlace { get; set; } = null!;
    public string Car { get; set; } = null!;
}
