using Microsoft.AspNetCore.Mvc;
using Tasks_For_ITI_MVC.Data;
using Tasks_For_ITI_MVC.Models;

namespace Tasks_For_ITI_MVC.Controllers
{
    public class ProductController : Controller
    {

            private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            if (products == null || !products.Any())
            {
                return NotFound("No products available.");
            }
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}



















  // private List<Product> products = new List<Product>
        // {
        //     new Product
        //     {
        //         Id = 1,
        //         Name = "Laptop",
        //         Price = 15000,
        //         ImageUrl = "/images/laptop.jpg",
        //         Description = "A powerful laptop for work and gaming."
        //     },
        //     new Product
        //     {
        //         Id = 2,
        //         Name = "Smartphone",
        //         Price = 8000,
        //         ImageUrl = "/images/phone.jpg",
        //         Description = "A modern smartphone with high-quality camera."
        //     },
        //     new Product
        //     {
        //         Id = 3,
        //         Name = "Headphones",
        //         Price = 1200,
        //         ImageUrl = "/images/headphones.jpg",
        //         Description = "Wireless headphones with noise cancellation."
        //     }
        // };