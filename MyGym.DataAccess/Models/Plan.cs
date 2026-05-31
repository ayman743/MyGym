namespace MyGym.DataAccess.Models
{
    public class Plan:BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int DurationInDays { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }= true;

        public ICollection<Membership> MemberShips { get; set; } = [];
    }
}
