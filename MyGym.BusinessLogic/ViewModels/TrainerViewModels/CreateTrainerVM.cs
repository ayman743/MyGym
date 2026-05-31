using MyGym.DataAccess.Enums;
using MyGym.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace MyGym.BusinessLogic.ViewModels.TrainerViewModels
{
    public class CreateTrainerVM
    {

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain letters only")]
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Form")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone Number Is Required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Phone number must be a valid Egyptian mobile number")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "DateOfBirth Is Required")]
        public DateOnly DateOfBirth { get; set; }


        [Required(ErrorMessage = "Gender Is Required")]
        public Gender? Gender { get; set; }


        [Required(ErrorMessage = "BuildingNumber Is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Building Number must be greater than 0")]
        public int? BuildingNumber { get; set; }


        [Required(ErrorMessage = "Street Is Required")]
        public string Street { get; set; }=null!;


        [Required(ErrorMessage = "City Is Required")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Specialties Is Required")]
        public Specialties? Specialties {  get; set; }
    }
}
