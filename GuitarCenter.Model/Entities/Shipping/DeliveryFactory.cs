using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Shipping
{
    public static class DeliveryFactory
    {
        public static IDeliveryOperator CreateDeliveryOperator(string operatorName)
        {
            if (operatorName == "Aks")
                return new AksDelivery();
            else
                return new BexDelivery();
        }
    }
}