using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
          


            builder.Property(b=>b.BloodType)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.Property(h => h.Height)
                    .HasPrecision(5, 2);

            builder.Property(h => h.Weight)
                .HasPrecision(5, 2);

            builder.Property(b => b.Note)
                .HasMaxLength(500);

            builder.HasOne(b=>b.Member)
                   .WithOne(m=>m.HealthRecord)
                   .HasForeignKey<HealthRecord>(h => h.MemberId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
