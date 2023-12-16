using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlantShop.Domain.Entities;

namespace PlantShop.DataAccess.Data.Config
{
    public class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal (18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.PlantCategory).WithMany()
               .HasForeignKey(p => p.PlantCategoryId);
            builder.HasOne(t => t.PlantType).WithMany()
              .HasForeignKey(p => p.PlantTypeId);
        }
    }
}
