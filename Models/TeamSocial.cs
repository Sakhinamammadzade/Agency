namespace Agency.Models
{
    public class TeamSocial:Base
    {
        public int SocialId { get; set; }
        public Social Social { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}
