namespace Agency.Models
{
    public class Team:Base
    {
        public string  PhotoUrl { get; set; }
        public string FullName { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }

    }
}