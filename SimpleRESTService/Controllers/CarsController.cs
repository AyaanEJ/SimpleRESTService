using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ObligatoriskOpgave_Car;
using SimpleRESTService.Managers;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public readonly CarManager _manager = new CarManager();
        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        
        public IEnumerable<Car> Get(int _maxPrice)
        {
            return _manager.GetAllCars(_maxPrice);
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public Car GetById(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public Car Post([FromBody] Car value)
        {
            return _manager.Add(value);
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
