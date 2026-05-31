using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CreatedAt)
                     .HasDefaultValueSql("GETDATE()");
            builder.HasKey(p=>p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);


           
        }
    }
}
