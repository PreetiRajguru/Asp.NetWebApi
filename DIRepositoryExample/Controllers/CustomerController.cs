using DIRepositoryExample.Services.Interfaces;
using DIRepositoryExample.Services.Services;
using Microsoft.AspNetCore.Mvc;
namespace DIRepositoryExample.WebApi.Controllers
{
    [Route("api/[controller]")]
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
            if (ModelState.IsValid)
            {
                return Ok(new
                {
                    message = "Customer List",
                    statusCode = StatusCodes.Status200OK,
                    result = _customerService.GetAll()
                });
            }
            return BadRequest(new
            {
                message = "Something Went Wrong",
                statusCode = StatusCodes.Status400BadRequest
            });
        }

        //get customer by id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(new
                {
                    message = $"Customer at {id}",
                    statusCode = StatusCodes.Status200OK,
                    result = _customerService.GetById(id)
                });
            }
            return BadRequest(new
            {
                message = "Something Went Wrong",
                statusCode = StatusCodes.Status400BadRequest
            });
        }

        //create new customer
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var id= _customerService.Create(customer);
                return Ok(new
                {
                    message = "Created Customer",
                    statusCode = StatusCodes.Status200OK,
                    result = id
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
                var Id = _customerService.Update(id, customer);
                return Ok(new
                {
                    message = "Updated Customer",
                    statusCode = StatusCodes.Status200OK,
                    result = Id
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
            if (ModelState.IsValid)
            {
                _customerService.Delete(id);
                return Ok(new
                {
                    message = $"Customer at {id} deleted",
                    statusCode = StatusCodes.Status200OK,
                });
            }
            return BadRequest(new
            {
                message = "Something Went Wrong",
                statusCode = StatusCodes.Status400BadRequest
            });
        }

    }
}