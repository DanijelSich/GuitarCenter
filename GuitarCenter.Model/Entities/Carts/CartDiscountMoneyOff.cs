using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Carts
{
    public class CartDiscountMoneyOff : ICartDiscountStrategy
    {
        public decimal GetTotalCostAfterApplyingDiscountTo(Cart cart)
        {
            if (cart.ComputeTotalValue() > 5000)
                return cart.ComputeTotalValue() - 500m;
            if (cart.ComputeTotalValue() > 2000)
                return cart.ComputeTotalValue() - 200m;
            else
                return cart.ComputeTotalValue();
        }
    }
}