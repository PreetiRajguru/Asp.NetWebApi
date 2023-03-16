using System.Collections.Generic;
using System.Linq;
using DIRepositoryExample.Services.Helper;
using DIRepositoryExample.Services.Interfaces;
namespace DIRepositoryExample.Services.Services
{
    public class LocationService : ILocation
    {
        public int CreateLocation(int customerId, CustomerLocation location)
        {
            Customer customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                customer.Locations.Add(location);
            }
            return (int)customer.Id;
        }

        public int UpdateLocation(int customerId, int locationId, CustomerLocation location)
        {
            Customer customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                CustomerLocation existingLocation = customer.Locations.FirstOrDefault(l => l.Id == locationId);
                if (existingLocation != null)
                {
                    existingLocation.Id = locationId;
                    existingLocation.Address = location.Address;
                }
            }
            return (int)customer.Id;
        }

        public bool DeleteLocation(int customerId, int locationId)
        {
            Customer customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                CustomerLocation location = customer.Locations.FirstOrDefault(l => l.Id == locationId);
                if (location != null)
                {
                    customer.Locations.Remove(location);
                    return true;
                }
            }
            return false;
        }

        public List<CustomerLocation> GetById(int customerId)
        {
            Customer customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                return customer.Locations;
            }
            return null;
        }
    }
}
