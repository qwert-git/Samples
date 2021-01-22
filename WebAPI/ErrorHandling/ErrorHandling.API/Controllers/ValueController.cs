using System;
using ErrorHandling.API.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int number) =>
         number switch
         {
             10 => throw new NotFoundException("Number 10 does not exists"),
             12 => throw new BadRequestException("Number 12 is out of range"),
             14 => throw new ArgumentException("Invalid number"),
             _ => Ok(number + 10)
         };
    }
}