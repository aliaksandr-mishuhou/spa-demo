using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Crap.Data.Entities;

namespace Crap.Data.Providers.EF.Mappings
{
    public class OrderMap : BaseMap<Order>
    {
        public OrderMap()
        {
            Property(t => t.Created).IsRequired();
            Property(t => t.Paid);
            Property(t => t.Processed);
            Property(t => t.Status).IsRequired();
            HasMany(t => t.Items).WithRequired(t => t.Order).HasForeignKey(t => t.OrderId);

            ToTable("Orders");
        }
    }
}
