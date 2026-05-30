using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class MemberConfiguration:UserConfiguration<Member>
    {
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.CreatedAt)
             .HasColumnName("JoinDate")
                 .HasDefaultValueSql("GETDATE()");

   

            base.Configure(builder);

               
            builder.Property(m => m.Photo)
                   .HasMaxLength(500);


           

        }
    }
}
