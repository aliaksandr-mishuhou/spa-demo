using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Crap.Data.Entities.Common;

namespace Crap.Data.Providers.EF.Mappings
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : Entity
    {
        protected BaseMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

    }
}
