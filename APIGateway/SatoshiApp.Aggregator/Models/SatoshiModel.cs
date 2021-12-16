using System.Collections.Generic;

namespace SatoshiApp.Aggregator.Models
{
    public class SatoshiModel
    {
        public string UserName { get; set; }
        public BasketModel BasketWithProducts { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}
