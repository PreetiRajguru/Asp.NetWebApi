using System;
using Microsoft.AspNetCore.Mvc;

namespace CustomerController.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        public static List<Customer> _customers = new List<Customer>();
        public static int _nextId = 1;

        //get all customers list
        [HttpGet]
        [Route("api/GetListOfCustomers")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(_customers);
        }

        //create customer
        [HttpPost]
        [Route("api/CreateCustomer")]
        public ActionResult<Customer> Create(Customer customer)
        {
            customer.Id = _nextId++;
            _customers.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        //get customer by id
        [HttpGet]
        [Route("api/GetCustomerById")]
        public ActionResult<Customer> GetById([FromQuery] int id)
        {
            return _customers.Find(c => c.Id == id);
        }

        [HttpPut]
        [Route("api/UpdateCustomer")]
        public ActionResult Update(int id, Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == id);
            /*_customers[index] = customer;*/
            //return NoContent();
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Locations = customer.Locations;
            return Ok($"==={existingCustomer}");
        }

        [HttpDelete]
        [Route("api/DeleteCustomer")]
        public ActionResult<Customer> DeleteCustomer([FromQuery] int id)
        {

            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            if (customer.Locations.Any())
            {
                return BadRequest("Cannot delete customer with locations");
            }

            _customers.Remove(customer);
            return Ok("Deleted Customer");
        }



        
        [HttpDelete]
        [Route("api/customers/locations")]
        public ActionResult DeleteLocation([FromQuery] int customerId, [FromQuery] int locationId)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
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
            return Ok($"{customerId},{locationId}");
        }
















        /*[HttpDelete]
        [Route("api/DeleteCustomer")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _customers.FindIndex(c => c.Id == id);
            //(CustomerController.Customer); 
            //string myString = (CustomerController.Customer)customer;
                //int myInt = (int)myDouble;
            if (customer == null)
            {
                return NotFound();
            }
            _customers.Remove(customer);
            return Ok("Deleted Customer");
        }*/






        /*  

          [HttpDelete("{id}")]
          [Route("api/DeleteCustomerAt")]
          public IActionResult Delete(int id)
          {
              var index = _customers.FindIndex(c => c.Id == id);
              if (index == -1)
              {
                  return NotFound();
              }
              _customers.RemoveAt(index);
              return NoContent();
          }
          [HttpGet("{customerId}/locations")]
          [Route("api/DisplayLocations")]
          public ActionResult<IEnumerable<CustomerLocation>> GetLocations(int customerId)
          {
              var customer = _customers.FirstOrDefault(c => c.Id == customerId);
              if (customer == null)
              {
                  return NotFound();
              }
              return customer.Locations;
          }*/

        /* [HttpGet("{customerId}/locations/{id}")]
         [Route("api/GetListOfCustomersAndLocations")]
         public ActionResult<CustomerLocation> GetLocation(int customerId, int id)
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
             return location;
         }*/
    }

}

