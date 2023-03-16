using System.Collections.Generic;
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
