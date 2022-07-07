using Agency.Models;
using Microsoft.EntityFrameworkCore;

namespace Agency.Data
{
    public class DataSeeding
    {
        private readonly AppDbContext _context;

        public DataSeeding(AppDbContext context)
        {
            _context = context;
        }

       public void SeedData()
        {
            if (_context.Database.GetPendingMigrations().Count() == 0)
            {
                if (_context.Portfolio.Count() == 0)
                {
                    _context.Portfolio.AddRange(Portfolios);
                }
                if (_context.Categories.Count() == 0)
                {
                    _context.Categories.AddRange(Categories);
                }
                _context.SaveChanges();
            }

        }
        public static Category[] Categories =
        {
            new Category(){CategoryName="Illustration"},
            new Category(){CategoryName="Web Design"},
            new Category(){CategoryName="Graghic Design"},

        };
        public static Portfolio[] Portfolios =
        {
            new Portfolio()
            {
                Title="Basliq 1",
                Description="Lorem ipsum dolor sit amet consectetur.",
                PhotoUrl="https://startbootstrap.github.io/startbootstrap-agency/assets/img/portfolio/1.jpg",
                Client="Client-1",
                Category=Categories[0]
            },
             new Portfolio()
            {
                Title="Basliq-2",
                Description="Lorem ipsum dolor sit amet consectetur.",
                PhotoUrl="https://startbootstrap.github.io/startbootstrap-agency/assets/img/portfolio/2.jpg",
                Client="Client-2",
                Category=Categories[1]
            },
              new Portfolio()
            {
                Title="Basliq-3",
                Description="Lorem ipsum dolor sit amet consectetur.",
                PhotoUrl="https://startbootstrap.github.io/startbootstrap-agency/assets/img/portfolio/3.jpg",
                Client="Client-3",
                Category=Categories[2]
            }
        };

    }
}
