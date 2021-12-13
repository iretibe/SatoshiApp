using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.Customer.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Entities.Customer>> GetCustomers();
        Task<Entities.Customer> GetCustomer(Guid id);
        Task<IEnumerable<Entities.Customer>> GetCustomerByName(string name);
        Task CreateCustomer(Entities.Customer Customer);
        Task UpdateCustomer(Entities.Customer Customer);
        Task DeleteCustomer(Guid id);
    }
}
