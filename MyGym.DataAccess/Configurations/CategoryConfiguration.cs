using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           

            builder.HasKey(p=>p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);


            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
