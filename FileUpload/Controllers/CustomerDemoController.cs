/*using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
    }
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }




    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private List<Customer> _customers = new List<Customer>
        {
        new Customer { Id = 1, Name = "First Customer",
            Locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Name = "Main Office",
                    Address = "123 Main St",
                    City = "Anytown",
                    State = "CA",
                    ZipCode = "12345"
                }
            }},
        new Customer { Id = 2, Name = "Second Customer",
         Locations = new List<Location>
            {
                new Location
                {
                    Id = 2,
                    Name = "Branch Office",
                    Address = "456 Second St",
                    City = "Othertown",
                    State = "NY",
                    ZipCode = "54321"
                },
                new Location
                {
                    Id = 3,
                    Name = "Warehouse",
                    Address = "789 Third St",
                    City = "Yetanothertown",
                    State = "TX",
                    ZipCode = "67890"
                }
            }
        }
        };









        // GET api/customers
        [HttpGet]
        [Route("DisplayCustomers")]
        public ActionResult GetCustomers()
        {
            return Ok(_customers);
        }

        // GET api/customers/{id}
        [HttpGet]
        [Route("GetCustomerById")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        [Route("PostCustomer")]
        public ActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            customer.Id = _customers.Max(c => c.Id) + 1;
            _customers.Add(customer);
            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // PUT api/customers/{id}
        [HttpPut]
        [Route("PutCustomer")]
        public ActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.Name = customer.Name;
            existingCustomer.Locations = customer.Locations;
            return Ok(existingCustomer);
        }

        // DELETE api/customers/{id}
        [HttpDelete]
        [Route("DeleteCustomer")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _customers.Remove(customer);
            return Ok();
        }






        // GET api/customers/{customerId}/locations
        [Route("api/customers/{customerId}/locations")]
        public ActionResult GetCustomerLocations(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer.Locations);
        }

        // GET api/customers/{customerId}/locations/{id}
        [Route("api/customers/{customerId}/locations/{id}")]
        public ActionResult GetCustomerLocation(int customerId, int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var location = customer.Locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST api/customers/{customerId}/locations
        [Route("api/customers/{customerId}/locations")]
        public ActionResult PostCustomerLocation(int customerId, Location location)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            location.Id = customer.Locations.Max(l => l.Id) + 1;
            customer.Locations.Add(location);
            return CreatedAtRoute("DefaultApi", new { controller = "Customers", customerId = customerId, id = location.Id }, location);
        }

        // PUT api/customers/{customerId}/locations/{id}
        [Route("api/customers/{customerId}/locations/{id}")]
        public ActionResult PutCustomerLocation(int customerId, int id, Location location)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var existingLocation = customer.Locations.FirstOrDefault(l => l.Id == id);
            if (existingLocation == null)
            {
                return NotFound();
            }
            existingLocation.Name = location.Name;
            existingLocation.Address = location.Address;
            existingLocation.City = location.City;
            existingLocation.State = location.State;
            existingLocation.ZipCode = location.ZipCode;
            return Ok();
        }

        // DELETE api/customers/{customerId}/locations/{id}
        [Route("api/customers/{customerId}/locations/{id}")]
        public ActionResult DeleteCustomerLocation(int customerId, int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var location = customer.Locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return NotFound();
            }
            customer.Locations.Remove(location);
            return Ok(location);
        }
    }
}

*/