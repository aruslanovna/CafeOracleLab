using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeWithOracle.Models
{
    public class Bill_date
    {
        public int Order_id { get; set; }

        public int Quantity { get; set; }
       

        public string Order_date { get; set; }

        public int Price { get; set; }

        public int Full_price { get; set; }
    }
}
