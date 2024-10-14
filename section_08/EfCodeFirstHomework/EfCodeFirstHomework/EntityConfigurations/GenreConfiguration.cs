using System.Data.Entity.ModelConfiguration;
using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}