using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGym.DataAccess.Models;

namespace MyGym.DataAccess.Configurations
{
    public class UserConfiguration<T> : IEntityTypeConfiguration<T>
       where T : User
    {

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {



            builder.Property(x => x.CreatedAt)
                  .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");


            builder.Property(x => x.Gender)
                .HasConversion<string>();

        
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(u => u.Phone)
                .IsUnique();

            builder.Property(x => x.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();



            builder.OwnsOne(u => u.Address, address =>
            {
                address.Property(a => a.City)
                       .HasColumnType("varchar(30)");

                address.Property(a => a.Street)
                       .HasColumnType("varchar(30)");

            });

            
            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                        "User_Phone_CK",
                        "LEN([Phone]) = 11 AND [Phone] LIKE '01[0125]%'"
                );
            });
            builder.Property(x => x.Phone)
                    .HasColumnType("varchar(11)")
                    .IsRequired();


        }
    }
}
