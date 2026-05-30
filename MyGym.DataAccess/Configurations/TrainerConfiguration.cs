using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class TrainerConfiguration : UserConfiguration<Trainer>
    {
        public override void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.HireDate)
                    .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue),
                    v => DateOnly.FromDateTime(v)
       )
                     .HasColumnType("date")
                     .HasDefaultValueSql("CAST(GETDATE() AS DATE)");

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");


            builder.Property(t => t.Specialty)
            .HasConversion<string>();

        }


    }
}

