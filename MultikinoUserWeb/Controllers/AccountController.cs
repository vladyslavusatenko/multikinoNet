using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using MultikinoUserWeb.Models;

namespace MultikinoUserWeb.Controllers
{
    public class AccountController : Controller
    {
        private MultikinoEntities db = new MultikinoEntities();

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(Uzytkownik model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = HashPassword(model.Haslo);
                var user = db.Uzytkownik.FirstOrDefault(u => u.Email == model.Email && u.Haslo == hashedPassword);
                if (user != null)
                {
                    if (user.Rola != "User")
                    {
                        ViewBag.Error = "This portal is for users only.";
                        return View(model);
                    }
                    Session["UserId"] = user.UzytkownikId;
                    Session["Role"] = user.Rola;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Error = "Invalid email or password.";
            }
            return View(model);
        }

        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                if (db.Uzytkownik.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email already registered.");
                    return View(model);
                }

                // Hash the password
                string hashedPassword = HashPassword(model.Haslo);

                // Create new user
                var user = new Uzytkownik
                {
                    Imie = model.Imie,
                    Nazwisko = model.Nazwisko,
                    Email = model.Email,
                    Haslo = hashedPassword,
                    Rola = "User" // Default role
                };
                db.Uzytkownik.Add(user);
                db.SaveChanges();

                TempData["Message"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login");
            }
            return View(model);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}