using Microsoft.AspNetCore.Mvc;
using CustomerLocation.Models;

namespace CustomerController.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public static List<Customer> customers = new List<Customer>();
        public static int _nextId = 1;

        //get all customers list
        [HttpGet]
        [Route("api/GetListOfCustomers")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(customers);
        }

        //create customer
        [HttpPost]
        [Route("api/CreateCustomer")]
        public ActionResult<Customer> Create(Customer customer)
        {
            customer.Id = _nextId++;
            customers.Add(customer);
            return Ok("Customer Created and Added to the List");
        }

        //get customer by id
        [HttpGet]
        [Route("api/GetCustomerById")]
        public ActionResult<Customer> GetById([FromQuery] int id)
        {
            return customers.Find(c => c.Id == id);
        }

        //update customer as well as location
        [HttpPut]
        [Route("api/UpdateCustomer")]
        public ActionResult UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.Name = customer.Name;
            existingCustomer.Locations = customer.Locations;
            return Ok($"Updated Customer");
        }

        //deleting customer
        [HttpDelete]
        [Route("api/DeleteCustomer")]
        public ActionResult<Customer> DeleteCustomer([FromQuery] int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            if (customer.Locations.Any())
            {
                return BadRequest("Cannot delete customer with locations");
            }
            customers.Remove(customer);
            return Ok("Deleted Customer");
        }

        //deleting locations
        [HttpDelete]
        [Route("api/customers/locations")]
        public ActionResult DeleteLocation(int customerId, int locationId)
        {
            var customer = customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var location = customer.Locations.FirstOrDefault(l => l.Id == locationId);
            if (location == null)
            {
                return NotFound();
            }
            customer.Locations.Remove(location);
            return Ok($"From Customer {customerId} removed location from {locationId}");
        }


        //get location by customer id
        [HttpGet]
        [Route("api/GetLocationByCustomerId")]
        public ActionResult<Customer> GetLocationByCustomerId([FromQuery] int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer.Locations);
        }

        //create location by customer id
        [HttpPost]
        [Route("api/CreateLocationByCustomerId")]
        public ActionResult PostCustomerLocation([FromQuery] int customerId, List<CustomerLocations> location)
        {
            var cust = customers.FirstOrDefault(c => c.Id == customerId);
            if (cust == null)
            {
                return NotFound();
            }
            cust.Locations = location;
            return Ok(cust.Locations);
        }

        //update location by customer id
        /*[HttpPost]
        [Route("api/UpdateLocationByCustomerId")]
        public ActionResult UpdateCustomerLocation([FromQuery] int customerId,[FromQuery] int locationId, List<CustomerLocations> location)
        {
            var cust = customers.FirstOrDefault(c => c.Id == customerId);
            if (cust == null)
            {
                return NotFound();
            }
            var locn = cust.Locations.FirstOrDefault(l => l.Id == locationId);
            if (locn == null)
            {
                return NotFound();
            }
            cust.Locations = location;
            return Ok(cust.Locations);
        }*/
    }
}