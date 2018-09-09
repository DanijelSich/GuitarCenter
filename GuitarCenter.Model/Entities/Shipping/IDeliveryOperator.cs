using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Shipping
{
    public interface IDeliveryOperator
    {
        decimal getDeliveryPrice();
        string getDeliveryTime();
    }
}