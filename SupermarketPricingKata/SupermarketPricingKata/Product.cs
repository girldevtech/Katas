using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPricingKata
{
    public class Product
    {
        public string Name { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal Cost { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Volume { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountRetailPrice { get; set; }
        public decimal? DiscountQuantity { get; set; }
    }
}
