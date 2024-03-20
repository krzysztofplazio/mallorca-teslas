using MallorcaTeslas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Repositories.Customers;

public interface ICustomersRepository
{
    Task<int> InsertCustomer(Customer customer, CancellationToken cancellationToken = default);
}
