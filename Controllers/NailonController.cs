using Microsoft.AspNetCore.Mvc;
using nailon.Entities;

namespace nailon.Controllers
{
    public class NailonController : Controller
    {
        private readonly testContext _context = new testContext();
        public NailonController(testContext testContext)
        {
            _context = testContext;
        }

        public IActionResult Index(){
            var prod = _context.Products.ToList();
            return View(prod);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product cat){

            _context.Products.Add(cat);
            _context.SaveChanges();

            return View("Index");
        }

        [HttpGet]
        public IActionResult Update(int id){
            var cat = _context.Products.Where(q => q.Id == id).FirstOrDefault();
            return View(cat);
        }

        [HttpPost]
        public IActionResult Update(Product c){
            var cat = _context.Products.Where(q => q.Id == c.Id).FirstOrDefault();
            cat.ProdName = c.ProdName;
            cat.Price = c.Price;

            _context.Products.Update(cat);
            _context.SaveChanges();

            return View("Index");
        }

        
    }
}