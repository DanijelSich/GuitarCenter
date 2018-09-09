using GuitarCenter.Model.Entities.Carts;
using GuitarCenter.Model.Entities.Shipping;

namespace GuitarCenter.Model.Entities.Orders
{
    public class Order
    {
        public Cart Cart { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public IDeliveryOperator DeliveryOperator { get; set; }
    }
}