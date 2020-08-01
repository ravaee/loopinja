using System;
using loppinja.Models.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using loppinja.Models.ViewModels.ActionViewModels.Home;
using loppinja.Models.Context;
using loppinja.Common.Models.Domains;

namespace loppinja.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected ILogger<T> _logger { get; set; }
        protected readonly ApplicationDbContext _dbContext;

        public BaseController(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            ILogger<T> logger,
                            ApplicationDbContext dbContext)
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._dbContext = dbContext;
        }

        public BaseController()
        {
        }


        protected IActionResult RedirectToExceptionPage(Exception e)
        {
            return RedirectToAction("ExceptionResult", "Home", new ExceptionResultViewModel { Exception = e});
        }
    }
}