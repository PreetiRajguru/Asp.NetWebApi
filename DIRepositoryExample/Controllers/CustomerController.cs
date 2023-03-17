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
                message = ConstantMessages.customerList,
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
                message = ConstantMessages.customerId,
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
                    message = ConstantMessages.customerCreated,
                    statusCode = StatusCodes.Status200OK,
                    result = response
                });
            }
            return BadRequest(new
            {
                message = ConstantMessages.errMessage,
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
                    message = ConstantMessages.customerUpdated,
                    statusCode = StatusCodes.Status200OK,
                    result = response
                });
            }
            return BadRequest(new
            {
                message = ConstantMessages.errMessage,
                statusCode = StatusCodes.Status400BadRequest
            });
        }

        //delete customer by id
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return _customerService.Delete(id)
            ? Ok(new
            {
                message = ConstantMessages.customerDeleted,
                statusCode = StatusCodes.Status200OK,
            })
            : BadRequest(new
              {
                  message = ConstantMessages.errMessage,
                  statusCode = StatusCodes.Status400BadRequest
              });
        }
    }
}