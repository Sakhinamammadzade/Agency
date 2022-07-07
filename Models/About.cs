namespace Agency.Models
{
    public class About: Base
    {
        public string Title { get; set; }
        public string  Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
