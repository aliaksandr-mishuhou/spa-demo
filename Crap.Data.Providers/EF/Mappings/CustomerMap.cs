using System.ComponentModel.DataAnnotations.Schema;
using Crap.Data.Entities;

namespace Crap.Data.Providers.EF.Mappings
{
    public class CustomerMap : BaseMap<Customer>
    {
        public CustomerMap()
        {
            Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            Property(t => t.LastName).IsRequired().HasMaxLength(50);
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.Password).IsRequired();
            HasMany(t => t.Orders).WithRequired(t => t.Customer).HasForeignKey(t => t.CustomerId);

            ToTable("Customers");
        }
    }
}
