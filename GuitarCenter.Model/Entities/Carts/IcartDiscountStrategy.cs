using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Carts
{
    public interface ICartDiscountStrategy
    {
        decimal GetTotalCostAfterApplyingDiscountTo(Cart cart);
    }
}