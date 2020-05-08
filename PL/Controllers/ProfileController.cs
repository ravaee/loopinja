using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using loppinja.Models.ViewModels.ActionViewModels.Account;
using Microsoft.AspNetCore.Identity;
using loppinja.Models.Domains;
using loppinja.Models.ViewModels.Partial;
using loppinja.Services;
using loppinja.Models.Context;
using loppinja.Models.ViewModels.ActionViewModels.Articles;
using loppinja.Models.ViewModels.ActionViewModels.Profile;
using loppinja.Models.Utilities;

namespace loppinja.Controllers
{
    public class ProfileController : BaseController<AccountController>
    {
        private readonly IEmailSender _emailSender;

        public ProfileController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ILogger<AccountController> logger,
                                 IEmailSender emailSender,
                                 ApplicationDbContext dbContext): 
                                 base(userManager, signInManager, logger, dbContext)
        {
            this._emailSender = emailSender;
        }


        [HttpGet]
        public async Task<ActionResult> Overview(string userId){

            
            
            var user = (userId != null) ? await _userManager.FindByIdAsync(userId) : null;
            
            var model = new OverviewViewModel();

            if(user == null) {

                model.MessageViewModel.Errors = new List<String>(){
                    "کابر مورد نظر یافت نشد"
                };

                return View(model);
            }

            model.MapViewModel = new MapViewModel();
            model.User = user;

            model.MapViewModel.items = new List<string>(){
                    "پروفایل کاربر" ,"مشاهده پروفایل", model.User.Email
            };
             

            return View(model);

        }

        [HttpPost]
        public ActionResult DateTimeTest(MRDateTime dateTime){

            var simpleDateTime = MRPersianDateTime.ToDateTime(dateTime.GetDateTime());
            dateTime.Day = simpleDateTime.Day;
            dateTime.Month = simpleDateTime.Month;
            dateTime.Year = simpleDateTime.Year;

            return View(dateTime);
        }

        [HttpGet]
        public ActionResult DateTimeTest(){

            return View();
        }

     
    }


    //test

        public class MRDateTime{
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public MRDateTime(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        public MRDateTime()
        {
            
        }

        public DateTime GetDateTime(){
            return new DateTime(Year, Month, Day);
        }
    }
}
