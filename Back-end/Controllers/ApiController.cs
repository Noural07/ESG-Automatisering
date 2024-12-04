using Microsoft.AspNetCore.Mvc;
using Back_end.Models;
using System.Collections.Generic;
using System.Linq;
using Back_end.Data.SensorDataRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly SensorDataRepository _repository;

        public ApiController(SensorDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var sensorData = _repository.GetAllSensorData();
            var filteredSensorData = sensorData.OrderBy(s => s.Timestamp).ToList();
            return Ok(filteredSensorData);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Back_end.Models.SensorData sensorData)
        {
            _repository.AddSensorData(sensorData);
            return CreatedAtAction(nameof(GetAll), new { id = sensorData.SensorId }, sensorData);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Back_end.Models.SensorData sensorData)
        {
            _repository.UpdateSensorData(sensorData);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string sensorId, DateTime timestamp)
        {
            _repository.DeleteSensorData(sensorId, timestamp);
            return NoContent();
        }
    }
}
