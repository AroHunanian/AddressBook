using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<User> user = _db.Users;
            return View(user);
        }

        // GET
        public  IActionResult Details(int? id)
        {
            if (id == null || _db.Users == null)
            {
                return NotFound();
            }
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                TempData["success"] = "New Address Created Successfully";
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                TempData["success"] = "Address Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
            TempData["success"] = "Address Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
