using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using ErgonomicsDatabase.Models;
using ErgonomicsDatabase.Models.ViewModels;

namespace ErgonomicsDatabase.Controllers
{
    public class LoginController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AccountRequested()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginViewModel model)
        {
            if (model.name.Length == 0 || model.name.Length > 128)
            {
                ModelState.AddModelError("name", "Please enter a valid name.");
            }

            Regex emailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            if (model.registerEmail.Length == 0 || model.registerEmail.Length > 128 || !emailRegex.IsMatch(model.registerEmail))
            {
                ModelState.AddModelError("registerEmail", "Please enter a valid email address.");
            }

            Regex passwordRegex = new Regex(@"^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{8,}$");
            if (model.registerEmail.Length > 64 || !passwordRegex.IsMatch(model.registerPassword))
            {
                ModelState.AddModelError("registerPassword", "Please enter a valid password. Passwords must be at least 8 characters long and contain at least one letter and one number.");
            }

            if (ModelState.IsValid)
            {
                using (PrototypeDatabaseContext db = new PrototypeDatabaseContext())
                {
                    TUser newUser = new TUser
                    {
                        VcUsername = model.name,
                        VcEmailAddress = model.registerEmail,
                        VcPassword = model.registerPassword,
                        BArchived = false,
                    };

                    try
                    {
                        db.Add(newUser);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("Error", "InternalServer");
                    }
                }
                return RedirectToAction("AccountRequested");
            }
            return View("Index", model);
        }
    }
}
