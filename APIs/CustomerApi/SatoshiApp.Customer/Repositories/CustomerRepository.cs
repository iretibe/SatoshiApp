using Microsoft.EntityFrameworkCore;
using SatoshiApp.Customer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoshiApp.Customer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateCustomer(Entities.Customer Customer)
        {
            await _context.Customer.AddAsync(Customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Guid id)
        {
            var prod = await _context.Customer.FirstOrDefaultAsync(p => p.CustomerId == id);
            _context.Customer.Remove(prod);
            await _context.SaveChangesAsync();
        }

        public async Task<Entities.Customer> GetCustomer(Guid id)
        {
            return await _context.Customer.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Customer>> GetCustomerByName(string name)
        {
            return await _context.Customer.Where(p => p.CustomerName == name).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task UpdateCustomer(Entities.Customer Customer)
        {
            _context.Customer.Update(Customer);

            //Commit the transaction
            await _context.SaveChangesAsync();
        }
    }
}
