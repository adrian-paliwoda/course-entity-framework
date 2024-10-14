using System.Data.Entity.ModelConfiguration;
using EfCodeFirstPlutoFluentAPI.Model;

namespace EfCodeFirstPlutoFluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);
            
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(p => p.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(p => p.Course);

            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });
        }
    }
}