using MyGym.DataAccess.Enums;

namespace MyGym.DataAccess.Models
{
    public class HealthRecord:BaseEntity
    {
       

        public decimal Height { get; set; }
        public decimal Weight { get; set; }


        public BloodType BloodType { get; set; }


        public string? Note { get; set; }


        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;


    }
}
