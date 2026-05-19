namespace MyGym.DataAccess.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateOnly Date {  get; set; }= DateOnly.FromDateTime(DateTime.Now);
        public bool IsAttended { get; set; }=false;

        public int SessionId {  get; set; }
        public int MemberId {  get; set; }

        public Session Session { get; set; } = null!;
        public Member Member { get; set; }=null!;

    }
}
