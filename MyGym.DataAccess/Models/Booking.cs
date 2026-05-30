namespace MyGym.DataAccess.Models
{
    public class Booking:BaseEntity
    {
       
       
        public bool IsAttended { get; set; }=false;

        public int SessionId {  get; set; }
        public int MemberId {  get; set; }

        public Session Session { get; set; } = null!;
        public Member Member { get; set; }=null!;

    }
}
