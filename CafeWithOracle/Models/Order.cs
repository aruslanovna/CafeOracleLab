using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeWithOracle.Models
{
    public class Order
    {
        public int Order_id { get; set; }
        public string  order_date { get; set; }
        public int Meal_id { get; set; }
        public int Quantity { get; set; }
    }
}
