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
                        .HasDefaultValueSql("GETDATE()");

                builder.Property(t => t.Specialty)
                .HasConversion<string>();

            }


    }
}

