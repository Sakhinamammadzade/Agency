using Agency.Data;
using Agency.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Services services)
        {
            _context.Services.Add(services);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }
        public IActionResult Edit(int id)
        {
            var services=_context.Services.FirstOrDefault(x=>x.Id==id);    

            return View(services);
        }
        [HttpPost]
        public IActionResult Edit(int id,Services service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
             var services=_context.Services.FirstOrDefault(x=>x.Id==id);
            return View(services);
        }

        [HttpPost]  
        public IActionResult Delete(int id,Services services)
        {
            _context.Services.Remove(services);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
      

    }
}
