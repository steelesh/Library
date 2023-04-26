namespace IT3047C_FinalProj.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Book> Favorites { get; set; } = new List<Book>();
        public virtual ICollection<Book> CurrentlyReading { get; set; } = new List<Book>();
        public virtual ICollection<Book> WantToRead { get; set; } = new List<Book>();
    }
}
