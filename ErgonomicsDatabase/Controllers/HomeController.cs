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
        public ViewResult Index()
        {
            var vm = new HomeViewModel();
            using (PrototypeDatabaseContext db = new PrototypeDatabaseContext())
            {
                vm.Handles = db.TObjectHandle.Select(a => new SelectListItem()
                {
                    Value = a.IObjectHandleId.ToString(),
                    Text = a.VcObjectHandle
                }).ToList();

                vm.Postures = db.TPosture.Select(a => new SelectListItem()
                {
                    Value = a.IPostureId.ToString(),
                    Text = a.VcPostureDetails
                }).ToList();

                vm.Rotations = db.TRotationAxis.Select(a => new SelectListItem()
                {
                    Value = a.TiRotationAxisId.ToString(),
                    Text = a.VcRotationAxis
                }).ToList();

                vm.Hands = db.THand.Select(a => new SelectListItem()
                {
                    Value = a.IHandId.ToString(),
                    Text = a.VcHand
                }).ToList();

                vm.Axes = db.TRotationAxis.Select(a => new SelectListItem()
                {
                    Value = a.TiRotationAxisId.ToString(),
                    Text = a.VcRotationAxis
                }).ToList();
            }
            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}