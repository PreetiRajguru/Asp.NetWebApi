using System.Collections.Generic;
using DIRepositoryExample.Services.Services;

namespace DIRepositoryExample.Services.Interfaces
{
    public interface ILocation
    {
        int CreateLocation(int customerId, CustomerLocation location);
        int UpdateLocation(int customerId, int locationId, CustomerLocation location);
        void DeleteLocation(int customerId, int locationId);
        List<CustomerLocation> GetById(int customerId);
    }
}
