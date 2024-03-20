using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Models;

public class Place
{
    public int Id { get; set; }
    public string Location { get; set; } = null!;
    public ICollection<Rental> Borrows { get; set; } = [];
    public ICollection<Rental> Returns { get; set; } = [];
}
