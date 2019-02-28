using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ErgonomicsDatabase.Models;
using ErgonomicsDatabase.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErgonomicsDatabase.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            using (PrototypeDatabaseContext db = new PrototypeDatabaseContext())
            {
                vm.Handles = db.TObjectHandle.Select(a => new SelectListItem()
                {
                    Value = a.IObjectHandleId.ToString(),
                    Text = a.VcObjectHandle
                }).ToList();
            }
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult NewEntry()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}