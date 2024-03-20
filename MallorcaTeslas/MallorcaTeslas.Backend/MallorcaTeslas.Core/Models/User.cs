using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public byte[] Password { get; set; } = [];
    public Customer Customer { get; set; } = null!;
}
