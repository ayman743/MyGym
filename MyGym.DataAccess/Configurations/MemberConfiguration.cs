using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class MemberConfiguration:UserConfiguration<Member>
    {
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);
        

            builder.Property(m => m.Photo)
                   .HasMaxLength(500);

            builder.Property(x => x.JoinDate)
                   .HasDefaultValueSql("GETDATE()");

           

        }
    }
}
