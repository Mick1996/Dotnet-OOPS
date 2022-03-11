using Database_First_Approach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Database_First_Approach.Controllers
{
    public class HomeController : Controller
    {
        UserContextDb db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,UserContextDb _db)
        {
            _logger = logger;
            db = _db;  
        }

        public IActionResult Index()
        {
            var userData = db.Users.Select(x=>x).ToList();
            return View(userData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateData(User user)
        {
           if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();   
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }
        [HttpPost]
        public IActionResult Edit(int id)
        {
            var user=db.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditData(User user)
        { 
            db.Users.Update(user);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int id)
        {
            var deleteUser=db.Users.Find(id);
            db.Users.Remove(deleteUser);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var result = db.Users.Find(id);
            return View(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}