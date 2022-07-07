using Agency.Data;
using Agency.Models;
using Agency.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agency.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly DataSeeding _data;

        public HomeController(AppDbContext context, DataSeeding data)
        {
            _context = context;
            _data = data;
        }


        //Banner banner = new()
        //{

        //    Id = 1,
        //    PhotoUrl = "https://startbootstrap.github.io/startbootstrap-creative/assets/img/bg-masthead.jpg",
        //    Title = "Welcome M001!",
        //    SubTitle = "IT'S NICE TO MEET YOU"

        //};




        public IActionResult Index()
        {
            var banner=_context.Banners.FirstOrDefault();
            var services=_context.Services.ToList();
            var about = _context.About.ToList();
            var portfolio = _context.Portfolio.Include(x=>x.Category).ToList();
            var teams = _context.Teams.Include(x => x.Position).ToList();
            var socials=_context.Socials.Include(x=>x.SocialNetwork).ToList();

            HomeVM vm = new()
            {
                Banner = banner,  //context.Banners.FirstOrDefault();
                Services=services,
                Abouts= about,
                Portfolios= portfolio,
                Socials= socials,
                Teams= teams, 
            };
         
            return View(vm);

        }
        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact)
        {
            _context.Contacts.Add(contact);
           await _context.SaveChangesAsync(); 
            return Ok();
        }
    }
}
