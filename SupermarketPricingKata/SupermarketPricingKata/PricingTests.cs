using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SupermarketPricingKata
{
    public class PricingTests
    {
        [Test]
        public void ThreeForOneDollarCalculatesCorrectlyWhenBuyingFourTest()
        {
            var productItem = new Product(){
                RetailPrice = 0.65M,
                Name = "Green Beans Canned",
                Cost = 0.25M,
                DiscountQuantity = 3,
                DiscountRetailPrice = 1.0M
            };

            var priceCalc = new Pricing(productItem);
            var totalRetail = priceCalc.CalculateTotalPrice(4);

            Assert.That(totalRetail, Is.EqualTo(1.65M));
        }

        [Test]
        public void ThreeForOneDollarReturnsRetailPriceOfOneDollarWhenBuyingThreeTest()
        {
            var productItem = new Product()
            {
                RetailPrice = 0.65M,
                Name = "Canned Peas",
                Cost = 0.25M,
                DiscountQuantity = 3,
                DiscountRetailPrice = 1.0M
            };

            var priceCalc = new Pricing(productItem);
            var totalRetail = priceCalc.CalculateTotalPrice(3);

            Assert.That(totalRetail, Is.EqualTo(1.0M));
        }

        [Test]
        public void DiscountPricingNotReceivedWhenNoneExistsTest()
        {
            var productItem = new Product()
            {
                RetailPrice = 2.99M,
                Cost = 1.25M,
                Name = "Ground Beef",
                Weight = 1.0M
            };

            var itemPriceCalc = new Pricing(productItem);
            var totalRetail = itemPriceCalc.CalculateTotalPrice(2.5M);

            Assert.That(totalRetail, Is.EqualTo(7.475M));
        }
    }
}
