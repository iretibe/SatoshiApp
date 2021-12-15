using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SatoshiApp.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SatoshiApp.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerRepository CustomerRepository, ILogger<CustomersController> logger)
        {
            _CustomerRepository = CustomerRepository ?? throw new ArgumentNullException(nameof(CustomerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet("GetCustomers")]
        [ProducesResponseType(typeof(IEnumerable<Entities.Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Customer>>> GetCustomers()
        {
            var Customers = await _CustomerRepository.GetCustomers();

            return Ok(Customers);
        }


        [HttpGet("GetCustomerById", Name = "GetCustomerById")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> GetCustomerById(Guid id)
        {
            var Customer = await _CustomerRepository.GetCustomer(id);

            if (Customer == null)
            {
                _logger.LogError($"Customer with id: {id}, not found.");

                return NotFound();
            }

            return Ok(Customer);
        }


        [Route("[action]/{name}", Name = "GetCustomerByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entities.Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Customer>>> GetCustomerByName(string name)
        {
            var items = await _CustomerRepository.GetCustomerByName(name);

            if (items == null)
            {
                _logger.LogError($"Customers with name: {name} not found.");
                return NotFound();
            }

            return Ok(items);
        }


        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Customer>> CreateCustomer([FromBody] Entities.Customer Customer)
        {
            await _CustomerRepository.CreateCustomer(Customer);

            return Ok(Customer);

            //return CreatedAtRoute("GetCustomer", new { id = Customer.CustomerId }, Customer);
        }


        [HttpPut("UpdateCustomer")]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCustomer([FromBody] Entities.Customer Customer)
        {
            return Ok(_CustomerRepository.UpdateCustomer(Customer));
        }


        [HttpDelete("DeleteCustomer", Name = "DeleteCustomer")]
        [ProducesResponseType(typeof(Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCustomerById(Guid id)
        {
            return Ok(_CustomerRepository.DeleteCustomer(id));
        }
    }
}
