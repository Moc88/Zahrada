using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OsevniPlan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OsevniPlan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
