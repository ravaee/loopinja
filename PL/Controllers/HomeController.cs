using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using loppinja.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using loppinja.Models.Domains;
using loppinja.Models.ViewModels.ActionViewModels.Home;
using loppinja.Models.Context;

namespace loppinja.Controllers
{
    public class HomeController : BaseController<HomeController>
    {

        public HomeController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                ILogger<HomeController> logger,
                                ApplicationDbContext dbContext): 
                                base(userManager, signInManager, logger, dbContext)
        {
            
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExceptionResult(ExceptionResultViewModel exceptionResult)
        {

            return View(exceptionResult);
        }
    }
}
