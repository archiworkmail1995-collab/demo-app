using Microsoft.AspNetCore.Mvc;
using VehicleApi.Interfaces;
using VehicleApi.Models;
using VehicleApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private IVehicle _vehicleService;
        public VehiclesController(IVehicle vehicleService)
        {       
            _vehicleService = vehicleService;  
                
        }
        // GET: api/<VehiclesController>
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehicles();  
            return vehicles;    
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public async Task<Vehicle> GetVehicleByID(int id)
        {
            return await _vehicleService.GetVehicleById(id);
            
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public async Task AddVehicle([FromBody] Vehicle vehicle)
        {
             await _vehicleService.AddVehicle(vehicle);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}")]
        public async Task UpdateVehicle(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleService.UpdateVehicle(id,vehicle);
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleService.DeleteVehicle(id);
        }
    }
}
