using MyGym.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyGym.DataAccess.Models
{
    public abstract class User : BaseEntity
    {
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string Phone { get; set; } = null!;


        public DateOnly? DateOfBirth { get; set; }

       

        public Gender Gender { get; set; }
        public Address Address { get; set; }=null!;
    }
}
