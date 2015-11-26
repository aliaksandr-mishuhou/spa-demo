using Crap.Data.Entities.Common;

namespace Crap.Data.Entities
{
    public class OrderItem : Entity
    {
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
