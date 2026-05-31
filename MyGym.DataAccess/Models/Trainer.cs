using MyGym.DataAccess.Enums;

namespace MyGym.DataAccess.Models
{
    public class Trainer : User
    {
        public Specialties Specialty { get; set; }   
        public DateOnly HireDate { get; set; }= DateOnly.FromDateTime(DateTime.Now);

        public ICollection<Session> Sessions { get; set; } = [];
    }
}
