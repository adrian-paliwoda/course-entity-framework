using System.Data.Entity.ModelConfiguration;
using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}