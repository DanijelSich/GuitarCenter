using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Shipping
{
    public class AksDelivery : IDeliveryOperator
    {
        public decimal getDeliveryPrice()
        {
            return 250;
        }

        public string getDeliveryTime()
        {
            return "3 radna dana";
        }
    }
}