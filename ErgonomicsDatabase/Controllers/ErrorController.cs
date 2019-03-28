using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ErgonomicsDatabase.Controllers
{
    /// <summary>
    /// Error controller. 
    /// Contains only view results that render the required error pages.
    /// </summary>
    public class ErrorController : Controller
    {
        public ViewResult Error403()
        {
            return View();
        }

        public ViewResult Error404()
        {
            return View();
        }

        public ViewResult Error500()
        {
            return View();
        }
    }
}
