using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {

            builder.HasOne(s => s.Category)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Trainer)
               .WithMany(c => c.Sessions)
               .HasForeignKey(s => s.TrainerId)
               .OnDelete(DeleteBehavior.NoAction);
        
            builder.ToTable(s =>
            {
                s.HasCheckConstraint(
                    "CK_Session_Capacity", "[Capacity] BETWEEN 1 AND 25");

                s.HasCheckConstraint(
                    "CK_Session_Date", "[StartDate] < [EndDate]");
            });

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
