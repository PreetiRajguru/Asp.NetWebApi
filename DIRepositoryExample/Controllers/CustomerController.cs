using DIRepositoryExample.Services.Interfaces;
using DIRepositoryExample.Services.Services;
using Microsoft.AspNetCore.Mvc;
namespace DIRepositoryExample.WebApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomer _customerService;

        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        //get all customers
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                message = "Customer List",
                statusCode = StatusCodes.Status200OK,
                result = _customerService.GetAll()
            });
        }

        //get customer by id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            return Ok(new
            {
                message = $"Customer at {id}",
                statusCode = StatusCodes.Status200OK,
                result = _customerService.GetById(id)
            });
        }

        //create new customer
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                int response = _customerService.Create(customer);
                return Ok(new
                {
                    message = "Created Customer",
                    statusCode = StatusCodes.Status200OK,
                    result = response
                });
            }
            return BadRequest(new
            {
                message = "Something Went Wrong",
                statusCode = StatusCodes.Status400BadRequest
            });
        }

        //update customer by id
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                int response = _customerService.Update(id, customer);
                return Ok(new
                {
                    message = "Updated Customer",
                    statusCode = StatusCodes.Status200OK,
                    result = response
                });
            }
            return BadRequest(new
            {
                message = "Something Went Wrong",
                statusCode = StatusCodes.Status400BadRequest
            });
        }

        //delete customer by id
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return Ok(new
            {
                message = $"Customer at {id} deleted",
                statusCode = StatusCodes.Status200OK,
            });
        }
    }
}