using Agency.Data;
using Agency.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allcategories=_context.Categories.ToList();
            return View(allcategories);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            var selectCategory=_context.Categories.FirstOrDefault(x=>x.CategoryName==category.CategoryName);
            if (selectCategory != null)
            {
                ViewBag.CategoryExist = "Category is exist";
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id==id);
            if (id == null)
            {
                return RedirectToAction("index");
            }
            if (category == null)
            {
                return NotFound();  
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var category=_context.Categories.FirstOrDefault(x=>x.Id==id);
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            try
            {
                if (category == null)
                {
                    return RedirectToAction("Index");
                }
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                var portfolio=_context.Portfolio.Where(x=>x.Id==category.Id).ToList();

                if (portfolio != null){
                    ViewBag.CategoryError = "Bu kategory arasinda portfolio olduguna gore sile bilmezsinsiniz";
                    ViewData["portfolio"] = portfolio;
                }
                else
                {
                    ViewBag.CategoryError = "Bilinmeyen sebebden error cixdi.Zehmet olmasa yeniden cehd edin";
                }

               return View();
            }
         }
    }
}
