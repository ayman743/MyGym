
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
           


            builder.Property(p => p.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();


            builder.Property(p => p.Description)
                .HasColumnType("varchar(200)");
                

            builder.Property(p => p.Price)
                .HasPrecision(10, 2);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.ToTable(tp =>
            {
                tp.HasCheckConstraint("CK_Plan_Duration", "DurationInDays between 1 and 365 ");
            });

            builder.HasQueryFilter(x => !x.IsDeleted);


        }
    }
}
