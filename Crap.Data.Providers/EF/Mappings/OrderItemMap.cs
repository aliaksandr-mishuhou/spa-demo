using System.ComponentModel.DataAnnotations.Schema;
using Crap.Data.Entities;

namespace Crap.Data.Providers.EF.Mappings
{
    public class OrderItemMap : BaseMap<OrderItem>
    {
        public OrderItemMap()
        {
            Property(t => t.Amount).IsRequired();
            Property(t => t.ProductId).IsRequired();
            HasRequired(t => t.Product);
            Property(t => t.OrderId).IsRequired();
            HasRequired(t => t.Order);

            ToTable("OrderItems");
        }
    }
}
