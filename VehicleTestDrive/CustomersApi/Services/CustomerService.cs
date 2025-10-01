using CustomerApi.Data;
using CustomersApi.Interfaces;
using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Services
{
    
    public class CustomerService : ICustomer
    {
        private ApiDbContext dbContext;
        public CustomerService()
        {
            dbContext=new ApiDbContext();
        }
        public async Task AddCustomer(Customer customer)
        {
           var vehicleInDb=await dbContext.Vehicle.FirstOrDefaultAsync(x => x.Id == customer.VehicleId);
            if(vehicleInDb==null)
            {
                await dbContext.Vehicle.AddAsync(customer.Vehicle);
                await dbContext.SaveChangesAsync();
            }
            customer.Vehicle = null;
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync(); 
        }
    }
}
