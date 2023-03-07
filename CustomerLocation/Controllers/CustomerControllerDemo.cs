/*using Microsoft.AspNetCore.Mvc;

namespace CustomerController.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        public static List<Customer> _customers = new List<Customer>();
        public static int _nextId = 1;

        [HttpGet]
        [Route("api/GetListOfCustomers")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customers;
        }

        [HttpPost]
        [Route("api/CreateCustomer")]
        public ActionResult<Customer> Create(Customer customer)
        {
            customer.Id = _nextId++;
            _customers.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }









        *//*   [HttpGet]
        [Route("api/GetCustomerById")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }*/



        /*
                [HttpPut("{id}")]
                [Route("api/UpdateCustomer")]
                public IActionResult Update(int id, Customer customer)
                {
                    var index = _customers.FindIndex(c => c.Id == id);
                    if (index == -1)
                    {
                        return NotFound();
                    }
                    _customers[index] = customer;
                    return NoContent();
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
         }*//*
    }

}

*/