using System;
using System.ComponentModel.DataAnnotations;

namespace SatoshiApp.Customer.Entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
    }
}
