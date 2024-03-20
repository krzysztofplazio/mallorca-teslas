using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Customers;
using MallorcaTeslas.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Repositories.Customers;

public class CustomersRepository(MallorcaTeslasDatabaseContext context) : ICustomersRepository
{
    private readonly MallorcaTeslasDatabaseContext _context = context;

    public async Task<int> InsertCustomer(Customer customer, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(customer, cancellationToken).ConfigureAwait(false);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return customer.Id;
    }
}
