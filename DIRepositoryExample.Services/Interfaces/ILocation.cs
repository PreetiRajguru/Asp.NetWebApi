using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIRepositoryExample.Services.Services;

namespace DIRepositoryExample.Services.Interfaces
{
    public interface ILocation
    {
        int CreateLocation(int customerId, CustomerLocations location);
        int UpdateLocation(int customerId, int locationId, CustomerLocations location);
        void DeleteLocation(int customerId, int locationId);
        List<CustomerLocations> GetLocationsByCustomerId(int customerId);
    }
}
