using DIRepositoryExample.Services.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using DIRepositoryExample.Services.Interfaces;
using DIRepositoryExample.Services.DTO;

namespace DIRepositoryExample.WebApi.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class CustomerLocationController : ControllerBase
    {
        public readonly ILocation _customerService;

        public CustomerLocationController(ILocation customerService)
        {
            _customerService = customerService;
        }

        //get locations by customer id
        [HttpGet]
        [Route("{customerId}")]
        public IActionResult GetById(int customerId)
        {
            var locations = _customerService.GetById(customerId);
            if (locations == null)
            {
                return NotFound();
            }

            var locationValue = new StringBuilder();
            foreach (var location in locations)
            {
                locationValue.AppendLine($"Location Id : {location.Id}\n Location : {location.Address}");
            }
            return Content(locationValue.ToString(), "text/plain");
        }

        //add location to customer
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] CustomerLocationDTO location)
        {
            if (ModelState.IsValid)
            {
                int response = _customerService.CreateLocation(location.CustomerId, new CustomerLocation { Id = location.Id, Address = location.Address });
                return Ok(new
                {
                    message = "Location Added to Customer List",
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

        //update location by customer id
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] CustomerLocationDTO location)
        {
            if (ModelState.IsValid)
            {
                int response = _customerService.UpdateLocation(location.CustomerId, id, new CustomerLocation { Id = location.Id, Address = location.Address });
                return Ok(new
                {
                    message = "Updated Location in Customer List",
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

        //delete location
        [HttpDelete]
        [Route("{customerId}/{locationId}")]
        public IActionResult Delete(int customerId, int locationId)
        {
            _customerService.DeleteLocation(customerId, locationId);
            return Ok(new
            {
                message = "Location Deleted",
                statusCode = StatusCodes.Status200OK,
                result = customerId
            });
        }
    }
}
