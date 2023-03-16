using System.Collections.Generic;
using System.Linq;
using DIRepositoryExample.Services.Helper;
using DIRepositoryExample.Services.Interfaces;
namespace DIRepositoryExample.Services.Services
{
    public class LocationService : ILocation
    {
        public int CreateLocation(int customerId, CustomerLocations location)
        {
            var customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                customer.Locations.Add(location);
            }
            return (int)customer.Id;
        }

        public int UpdateLocation(int customerId, int locationId, CustomerLocations location)
        {
            var customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                var existingLocation = customer.Locations.FirstOrDefault(l => l.Id == locationId);
                if (existingLocation != null)
                {
                    existingLocation.Id = locationId;
                    existingLocation.Address = location.Address;
                }
            }
            return (int)customer.Id;
        }

        public void DeleteLocation(int customerId, int locationId)
        {
            var customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                var location = customer.Locations.FirstOrDefault(l => l.Id == locationId);
                if (location != null)
                {
                    customer.Locations.Remove(location);
                }
            }
        }

        public List<CustomerLocations> GetLocationsByCustomerId(int customerId)
        {
            var customer = CustomerHelper.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                return customer.Locations;
            }

            return null;
        }
    }
}
