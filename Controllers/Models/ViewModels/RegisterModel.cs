using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductionsProductionCompany.Models.ViewModels
{
    public class RegisterModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
