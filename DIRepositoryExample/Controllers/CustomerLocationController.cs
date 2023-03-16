using DIRepositoryExample.Services.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using DIRepositoryExample.Services.Interfaces;

namespace DIRepositoryExample.WebApi.Controllers
{
    [Route("api/[controller]")]
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
        [Route("{customerId}")]
        public IActionResult Create(int customerId, [FromBody] CustomerLocations location)
        {
            if (ModelState.IsValid)
            {
                var id = _customerService.CreateLocation(customerId, location);
                //_customerService.CreateLocation(customerId, location);
                return Ok(new
                {
                    message = "Location Added to Customer List",
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

        //update location by customer id
        [HttpPut]
        [Route("{customerId}/{locationId}")]
        public IActionResult Update(int customerId, int locationId, [FromBody] CustomerLocations location)
        {
            if (ModelState.IsValid)
            {
                var id = _customerService.UpdateLocation(customerId, locationId, location);
                //_customerService.UpdateLocation(customerId, locationId, location);
                return Ok(new
                {
                    message = "Updated Location in Customer List",
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
