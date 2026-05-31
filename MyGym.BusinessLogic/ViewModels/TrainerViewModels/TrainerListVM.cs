using MyGym.DataAccess.Enums;

namespace MyGym.BusinessLogic.ViewModels.TrainerViewModels
{
    public class TrainerListVM
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; }=null!;
        public string Phone {  get; set; }=null!;
        public Specialties Specialties { get; set; }
    }
}
