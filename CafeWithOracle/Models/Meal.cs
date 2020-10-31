using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeWithOracle.Models
{
    public class Meal
    {
         public int Meal_id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Cart_id { get; set; }
        public int Price { get; set; }

        public string Best_before { get; set; }

    }
}
