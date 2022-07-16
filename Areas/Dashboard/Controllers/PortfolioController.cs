using Agency.Data;
using Agency.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agency.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
     public PortfolioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var portfolio=_context.Portfolio.Include(x=>x.Category).ToList();
            return View(portfolio);
        }
        public IActionResult Create()
        {
            ViewData["Categories"]= _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create (Portfolio portfolio,string myCategory,IFormFile NewPhoto)
        {

            var fileExtation = Path.GetExtension(NewPhoto.FileName);

            string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", myPhoto);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                NewPhoto.CopyTo(stream);
            }
            var cat = _context.Categories.FirstOrDefault(x => x.CategoryName == myCategory);
            portfolio.CategoryId = cat.Id;
            portfolio.PhotoUrl = "image/" + myPhoto;
            _context.Portfolio.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var portfolio = _context.Portfolio.FirstOrDefault(x=>x.Id==id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View (portfolio);
        }
        [HttpPost]

        public IActionResult Edit(int id,Portfolio portfolio,IFormFile NewPhoto,string?oldPhoto)
        {

            if (NewPhoto != null)
            {
                var fileExtation = Path.GetExtension(NewPhoto.FileName);

                string myPhoto = Guid.NewGuid().ToString() + Path.GetExtension(NewPhoto.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", myPhoto);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    NewPhoto.CopyTo(stream);
                }
                portfolio.PhotoUrl = "image/" + myPhoto;
            }
            else
            {
                portfolio.PhotoUrl = oldPhoto;
            }

            _context.Portfolio.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }

        public IActionResult Delete(int id)
        {
            var portfolio = _context.Portfolio.FirstOrDefault(x=>x.Id==id); 
            return View(portfolio);
        }
        [HttpPost]
        public IActionResult Delete (int id,Portfolio portfolio)
        {
            if (portfolio == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _context.Portfolio.Remove(portfolio);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
