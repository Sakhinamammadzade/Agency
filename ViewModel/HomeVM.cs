using Agency.Models;

namespace Agency.ViewModel
{
    public class HomeVM
    {
        public Banner Banner { get; set; }
        public List<Services> Services { get; set; }
        public List<About>Abouts { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<Team> Teams{ get; set; }
        public List<Social> Socials { get; set; }



    }
}
