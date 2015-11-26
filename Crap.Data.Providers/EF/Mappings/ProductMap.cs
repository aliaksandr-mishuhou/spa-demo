using Crap.Data.Entities;

namespace Crap.Data.Providers.EF.Mappings
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap()
        {
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.Price).IsRequired();
            Property(t => t.AvailableAmount).IsRequired();
            Property(t => t.CategoryId).IsRequired();
            //HasRequired(t => t.Category).WithMany(t => t.Products).HasForeignKey(t => t.CategoryId);

            ToTable("Products");
        }
    }
}
