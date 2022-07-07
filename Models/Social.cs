namespace Agency.Models
{
    public class Social:Base
    {
        public int SocialNetworkId{ get; set; }
        public SocialNetwork SocialNetwork { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string SocialUrl{ get; set; }
    
    }
}
