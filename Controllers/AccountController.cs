using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Paket;
using System.Security.Claims;
using task.Data;
using task.Models;
using Microsoft.AspNetCore.Authorization;

namespace task.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _dbContext;
        public AccountController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Emp obj)
        {
            _dbContext.Emp.Add(obj);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

                if (AuthenticateUser(model.UserName, model.Password))
                {
                    return RedirectToDashboard(model.UserName);
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect username or password.";

                }
            return View(model);
        }
        private bool AuthenticateUser(string username, string password)
        {
            var user = _dbContext.Emp.SingleOrDefault(u => u.UserName == username && u.Password == password);
            return user != null;
        }

        private IActionResult RedirectToDashboard(string username)
        {
            var userRoles = _dbContext.Emp.SingleOrDefault(u => u.UserName == username)?.Roles;


            if (userRoles.Contains("HR"))
            {
                return RedirectToAction("HRView", "Account");
            }
            else if (userRoles.Contains("Admin"))
            {
                return RedirectToAction("AdminView", "Account");
            }
            else if (userRoles.Contains("IT"))
            {
                return RedirectToAction("ITView", "Account");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }







    } 

}
