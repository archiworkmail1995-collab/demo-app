using Microsoft.EntityFrameworkCore;
using VehicleApi.Data;
using VehicleApi.Interfaces;
using VehicleApi.Models;

namespace VehicleApi.Services
{
    public class VehicleService : IVehicle
    {
        private ApiDbContext dbContext;
        public VehicleService()
        {
            dbContext = new ApiDbContext();
        }
        public async Task AddVehicle(Vehicle vehicle)
        {
           await dbContext.Vehicle.AddAsync(vehicle);
            dbContext.SaveChangesAsync();
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicle=await dbContext.Vehicle.FindAsync(id); 
            dbContext.Vehicle.Remove(vehicle);
            dbContext.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            var vehicles = await dbContext.Vehicle.ToListAsync();
            return vehicles;
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            var vehicle = await dbContext.Vehicle.FindAsync(id);
            return vehicle;
        }

        public async Task UpdateVehicle(int id, Vehicle vehicle)
        {
            var vehicleobj=await dbContext.Vehicle.FindAsync(id);
            vehicleobj.Name= vehicle.Name;  
            vehicleobj.Price= vehicle.Price;    
            vehicleobj.Displacement=vehicle.Displacement;
            vehicleobj.Length=vehicle.Length;
            vehicleobj.ImageUrl=vehicle.ImageUrl;   
            vehicleobj.Id=vehicle.Id;   
            vehicleobj.Width=vehicle.Width;
            vehicleobj.MaxSpeed=vehicle.MaxSpeed;
            await dbContext.SaveChangesAsync();
        }
    }
}
