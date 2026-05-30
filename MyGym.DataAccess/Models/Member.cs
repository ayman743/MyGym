namespace MyGym.DataAccess.Models
{
    public class Member:User
    {
        public string? Photo {  get; set; }
        

        public HealthRecord HealthRecord { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = [];
        public ICollection<Membership> Memberships { get; set; } = [];

    }
}
