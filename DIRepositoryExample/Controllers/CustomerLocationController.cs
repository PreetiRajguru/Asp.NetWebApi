using DIRepositoryExample.Services.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using DIRepositoryExample.Services.Interfaces;
using DIRepositoryExample.Services.Dtos;

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

        //get location by customer id
        [HttpGet]
        [Route("{customerId}")]
        public IActionResult GetById(int customerId)
        {
            if (ModelState.IsValid)
            {
                var locations = _customerService.GetLocationsByCustomerId(customerId);
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
            return BadRequest(new
            {
                message = "Something Went Wrong",
                statusCode = StatusCodes.Status400BadRequest
            });
        }


        //add location to customer
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] CustomerLocationDto location)

        {
            if (ModelState.IsValid)
            {
                var idRes = _customerService.CreateLocation(location.CustomerId, new CustomerLocations { Id = location.Id, Address = location.Address });
                return Ok(new
                {
                    message = "Location Added to Customer List",
                    statusCode = StatusCodes.Status200OK,
                    result = idRes
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
        public IActionResult Update(int id, [FromBody] CustomerLocationDto location)
        {
            if (ModelState.IsValid)
            {
                var idRes = _customerService.UpdateLocation(location.CustomerId, id, new CustomerLocations { Id = location.Id, Address = location.Address });
                return Ok(new
                {
                    message = "Updated Location in Customer List",
                    statusCode = StatusCodes.Status200OK,
                    result = idRes
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
            if (ModelState.IsValid)
            {
                _customerService.DeleteLocation(customerId, locationId);
                return Ok(new
                {
                    message = "Location Deleted",
                    statusCode = StatusCodes.Status200OK,
                    result = customerId
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
