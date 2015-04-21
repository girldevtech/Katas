using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPricingKata
{
    public class Pricing
    {
        public Product purchaseItem { get; set; }

        public Pricing(Product productItem)
        {
            purchaseItem = productItem;
        }
        
        public decimal CalculateTotalPrice(decimal quantityToPurchase)
        {
            var totalPurchasePrice = 0.0M;

            if (IsQuantityDiscount(purchaseItem, quantityToPurchase))
                totalPurchasePrice = CalculateQuantityDiscount(purchaseItem, quantityToPurchase);
            else
                totalPurchasePrice = CalculateFullRetail(purchaseItem, quantityToPurchase);
            
            return totalPurchasePrice;
        }

        private decimal CalculateFullRetail(Product purchaseItem, decimal quantityToPurchase)
        {
            return (decimal)purchaseItem.RetailPrice * quantityToPurchase;
        }

        private decimal CalculateQuantityDiscount(Product purchaseItem, decimal quantityToPurchase)
        {
            var totalDiscountPrice = 0.0M;

            if (purchaseItem.DiscountQuantity == quantityToPurchase)
            {
                totalDiscountPrice = (decimal)purchaseItem.DiscountRetailPrice;
            }
            else
            {
                var numberOfIterations = quantityToPurchase % 3;
                for (int i = 1; i <= numberOfIterations; i++)
                {
                    totalDiscountPrice = (decimal)purchaseItem.DiscountRetailPrice;
                    quantityToPurchase = quantityToPurchase - (decimal)purchaseItem.DiscountQuantity;
                    if (quantityToPurchase < purchaseItem.DiscountQuantity)
                        break;
                }
                totalDiscountPrice += purchaseItem.RetailPrice * quantityToPurchase;
            }

            return totalDiscountPrice;
        }

        private bool IsQuantityDiscount(Product productItem, decimal quantityToPurchase)
        {
            if (productItem.DiscountQuantity > 1 
                && quantityToPurchase >= productItem.DiscountQuantity)
                return true;

            return false;
        }
    }
}
