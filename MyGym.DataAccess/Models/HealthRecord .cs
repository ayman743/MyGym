using MyGym.DataAccess.Enums;

namespace MyGym.DataAccess.Models
{
    public class HealthRecord
    {
        public int Id { get; set; }

        public decimal Height { get; set; }
        public decimal Weight { get; set; }


        public BloodType BloodType { get; set; }


        public string? Note { get; set; }


        public DateTime LastUpdate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;


    }
}
