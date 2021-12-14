using System;
using System.ComponentModel.DataAnnotations;

namespace SatoshiApp.ProductApi.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
