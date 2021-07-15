using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Test.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Show home view
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Show one project info
        /// </summary>
        public IActionResult Project()
        {
            return View();
        }

        /// <summary>
        /// Show task edit formn
        /// </summary>
        public IActionResult Edit()
        {
            return View();
        }
    }
}
