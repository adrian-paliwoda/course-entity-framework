using System.Data.Entity.ModelConfiguration;
using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.EntityConfigurations
{
    public class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(v => v.Classification)
                .HasColumnType("tinyint");

            HasRequired(p => p.Genre)
                .WithMany(c => c.Videos)
                .HasForeignKey(p => p.GenreId);

            HasMany(p => p.Tags)
                .WithMany(t => t.Videos)
                .Map(m =>
                {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("VideoId");
                    m.MapRightKey("TagId");
                });
        }
    }
}