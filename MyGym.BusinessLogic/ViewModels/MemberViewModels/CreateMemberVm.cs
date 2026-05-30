
using Microsoft.AspNetCore.Http;
using MyGym.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyGym.BusinessLogic.ViewModels.MemberViewModels
{
    public class CreateMemberVm
    {
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain letters only")]
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Form")]
        public string Email { get; set; } = default!;

        public string? Photo { get; set; }

     


        [Required(ErrorMessage = "Phone Number Is Required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Phone number must be a valid Egyptian mobile number")]
        public string Phone { get; set; } = default!;


        [Required(ErrorMessage = "Date of Birth is required")]
        public DateOnly DateOfBirth { get; set; }



        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; } = default!;



        [Range(1, int.MaxValue, ErrorMessage = "Building Number must be greater than 0")]
        [Required]
        public int BuildingNumber { get; set; }


        [Required]

        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s\-\/]+$", ErrorMessage = "Invalid street name")]
        public string Street { get; set; } = default!;


        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "City must contain letters only")]
        public string City { get; set; } = default!;

        [Required(ErrorMessage = "Health record is required")]
        public HealthRecordVm HealthRecord { get; set; } = default!;

    }
}
