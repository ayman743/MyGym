using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.CreatedAt)
                .HasColumnName("BookingDate")
                    .HasDefaultValueSql("GETDATE()");



            builder.HasOne(b => b.Member)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MemberId).
                OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(b => b.Session)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.SessionId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(b => new { b.MemberId, b.SessionId })
                .IsUnique();

            builder.Property(x => x.IsAttended)
                 .HasDefaultValue(false);

           

        }
    }
}
