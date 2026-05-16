
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.Presentation.Models;

namespace MyGym.Presentation.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(p => p.Id);


            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(p => p.IsActive)
                .HasDefaultValueSql("true");

            builder.Property(p => p.Price)
                .HasPrecision(10, 2);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.ToTable(tp =>
            {
                tp.HasCheckConstraint("CK_Plan_Duration", "DurationInDays between 1 and 365 ");
            });

        }
    }
}
