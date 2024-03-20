using MallorcaTeslas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Repositories.Places;

public interface IPlacesRepository
{
    Task<Place?> GetPlaceById(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Place>> GetPlaces(CancellationToken cancellationToken = default);
}
