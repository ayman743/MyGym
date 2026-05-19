using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            
            builder.Property(x => x.StartDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(ms => ms.Plan)
                   .WithMany(m => m.MemberShips)
                   .HasForeignKey(x => x.PlanId)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(ms => ms.Member)
                    .WithMany(m => m.Memberships)
                    .HasForeignKey(x => x.MemberId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(ms =>
            {
                ms.HasCheckConstraint(
                    "CK_Membership_DateRange",
                    "[StartDate] < [EndDate]"
                    );
            });

          

            



        }
    }
}
