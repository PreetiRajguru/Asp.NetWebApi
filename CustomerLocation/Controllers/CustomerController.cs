using Microsoft.AspNetCore.Mvc;
using CustomerLocation.Models;

namespace CustomerController.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> customers = new List<Customer>();
        public static int nextId = 1;

        /// <summary>
        /// Display all customers
        /// </summary>
        /// /// <returns>Displays a list of customers </returns>
        /// <remarks>
        /// Sample request:
        ///
        ///GET
        ///[
        ///{
        ///"id": 0,
        ///"name": "string",
        ///"locations": [
        /// {
        /// "id": 0,
        ///"address": "string"
        ///}
        ///]
        /// }
        ///]
        ///
        /// </remarks>
        /// <response code="200">Returns the customers list</response>
        /// <response code="400">If the list is null</response>
        /// <response code="404">If customer list is not found</response>
        //get all customers list
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            //return Ok(customers);
            var response = new
            {
                statusCode = 200,
                message = "Fetching customers list",
                data = customers
            };
            return new ObjectResult(response);
        }

        /// <summary>
        /// Create customer
        /// </summary>
        //create customer
        [HttpPost]
        [Route("create_customer")]
        public ActionResult<Customer> Create(Customer customer)
        {
            customer.Id = nextId++;
            customers.Add(customer);
            var response = new
            {
                statusCode = 200,
                message = "Customer created successfully",
                data = customers
            };
            return new ObjectResult(response);
        }

        /// <summary>
        /// Get customer 
        /// </summary>
        //get customer by id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var response = new
            {
                statusCode = 200,
                message = "Customer fetched successfully",
                data = customers.Find(c => c.Id == id)
            };
            return new ObjectResult(response);
        }

        /// <summary>
        /// Update customer
        /// </summary>
        //update customer 
        [HttpPut]
        [Route("update_customer/{id}")]
        public ActionResult UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.Name = customer.Name;
            existingCustomer.Locations = customer.Locations;
            var response = new
            {
                statusCode = 200,
                message = "Update Customer Successful",
                data = customers
            };
            return new ObjectResult(response);
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        //deleting customer
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Customer> DeleteCustomer(int id)
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
            var response = new
            {
                statusCode = 200,
                message = "Delete Customer Successful",
                data = customers
            };
            return new ObjectResult(response);
        }

        /// <summary>
        /// Delete location 
        /// </summary>
        //deleting locations
        [HttpDelete]
        [Route("{customerId}/location/{locationId}")]
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
            var response = new
            {
                statusCode = 200,
                message = "Remove Location Successful",
                data = customers
            };
            return new ObjectResult(response);
        }


        /// <summary>
        /// Get location 
        /// </summary>
        //get location 
        [HttpGet]
        [Route("location/{id}")]
        public ActionResult<Customer> GetLocationByCustomerId(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var response = new
            {
                statusCode = 200,
                message = "Get Location Successful",
                data = customer.Locations
            };
            return new ObjectResult(response);
        }

        /// <summary>
        /// Create location 
        /// </summary>
        //create location 
        [HttpPost]
        [Route("create_location/{customerId}")]
        public ActionResult PostCustomerLocation(int customerId, List<CustomerLocations> location)
        {
            var cust = customers.FirstOrDefault(c => c.Id == customerId);
            if (cust == null)
            {
                return NotFound();
            }
            cust.Locations = location;
            var response = new
            {
                statusCode = 200,
                message = "Create Location Successful",
                data = cust.Locations
            };
            return new ObjectResult(response);
        }

        //update location by customer id
        /// <summary>
        /// Update location 
        /// </summary>
        [HttpPut]
        [Route("update_location/{custid}/{locnid}")]
        public ActionResult<Customer> UpdateCustomerLocation(int custid, int locnid, [FromBody] CustomerLocations location)
        {
            foreach (var customer in customers)
            {
                if (customer.Id == custid)
                {
                    if (customer.Locations != null)
                    {
                        foreach (var currentLocation in customer.Locations)
                        {
                            if (currentLocation.Id == locnid)
                            {
                                currentLocation.Id = location.Id;
                                currentLocation.Address = location.Address;
                                return Ok(currentLocation);
                            }
                            return Ok("Location not found");
                        }
                    }
                }
            }
            return BadRequest("Customer not found");
        }
    }
}