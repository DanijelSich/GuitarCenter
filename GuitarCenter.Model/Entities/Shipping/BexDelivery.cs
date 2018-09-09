using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Shipping
{
    public class BexDelivery : IDeliveryOperator
    {
        public decimal getDeliveryPrice()
        {
            return 300M;
        }

        public string getDeliveryTime()
        {
            return "2 radna dana";
        }
    }
}