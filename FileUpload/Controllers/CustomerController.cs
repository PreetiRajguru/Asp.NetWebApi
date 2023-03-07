/*using Microsoft.AspNetCore.Mvc;

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
        public string Address { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> _customers = new List<Customer>
        {
        new Customer { Id = 1, Name = "First Customer",
            Locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Address = "Pune",
                }
            }},
            new Customer { Id = 2, Name = "Second Customer",
                Locations = new List<Location>
                    {
                    new Location
                    {
                        Id = 2,
                        Address = "Ahmednagar",
                    },
                    new Location
                    {
                        Id = 2,
                        Address = "Mumbai",
                    }
                }
            },
            new Customer { Id = 3, Name = "Third Customer",
                Locations = new List<Location>
                {
                    new Location
                    {
                    Id = 1,
                    Address = "Dont Know",
                    }
                }
            },
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
            var customer = _customers.First(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


        // DELETE api/customers/{id}
        [HttpDelete]
        [Route("DeleteCustomer")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _customers.First(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            //_customers.Remove(customer);
            _customers.Remove(_customers.First(c => c.Id == id));
            return Ok("Deleted Customer");
        }

    }
}


*/