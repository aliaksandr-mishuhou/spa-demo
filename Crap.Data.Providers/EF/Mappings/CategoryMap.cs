using Crap.Data.Entities;

namespace Crap.Data.Providers.EF.Mappings
{
    public class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(t => t.Products).WithRequired(t => t.Category).HasForeignKey(t => t.CategoryId);

            ToTable("Categories");
        }
    }
}
