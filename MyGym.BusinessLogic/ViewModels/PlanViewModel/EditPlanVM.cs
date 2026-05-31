using System.ComponentModel.DataAnnotations;

namespace MyGym.BusinessLogic.ViewModels.PlanViewModel
{
    public class EditPlanVM
    {
        [Required]
        public string Name { get; set; } = null!;


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0.")]
        public int? DurationInDays { get; set; }


        [Required]
        [Range(typeof(decimal), "0.01", "999999999999999999",
            ErrorMessage = "Price must be greater than 0.")]
        public decimal? Price { get; set; }


        [Required]
        public string Description { get; set; } = null!;
    }
}
