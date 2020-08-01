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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using loppinja.Models.Context;
using loppinja.Common.Models.Domains;

namespace loppinja.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ILogger<AccountController> logger,
                                 IEmailSender emailSender,
                                 ApplicationDbContext dbContext): 
                                 base(userManager, signInManager, logger, dbContext)
        {
            this._emailSender = emailSender;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password,true, false);

            if (result.Succeeded)
            {

                if(!String.IsNullOrEmpty(returnUrl)){
                
                    return Redirect(returnUrl);
                }
                
                return RedirectToAction(nameof(HomeController.Secret), "Home");
            }
            

            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
        {
            try
            {
                var user = new ApplicationUser{
                    UserName = newUser.Email,
                    Email = newUser.Email,
                };

                var createUser = await this._userManager.CreateAsync(user, newUser.Password);

                if(createUser.Succeeded){

                    var token = await this._userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account", 
                                            new { userId = user.Id, token = token }, Request.Scheme);


                    await _emailSender.SendEmailAsync(user.Email, "لینک فعالسازی اکانت لوپ مگ", confirmationLink);

                    newUser.MessageViewModel.Messages.Add(" ایمیلی جهت فعال سازی اکانت شما برایتان ارسال شد");

                }else{

                    foreach(var error in createUser.Errors){

                        newUser.MessageViewModel.Errors.Add(error.Description);
                    }
                }
            }
            catch(Exception e)
            {
                newUser.MessageViewModel.Errors.Add(e.Message);
            }

            return View(newUser);
            
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {

            try{

                if(userId == null || token == null){

                    return RedirectToAction("Index", "Home");
                }

                var user = await _userManager.FindByIdAsync(userId);

                if(user == null){

                    return RedirectToAction("Index", "Home");
                }

                var result = await _userManager.ConfirmEmailAsync(user, token);

                if(!result.Succeeded)
                {
                    LoginViewModel loginViewModel = new LoginViewModel();

                    foreach(var error in result.Errors){

                        loginViewModel.MessageViewModel.Errors.Add(error.ToString());
                    }

                    return RedirectToAction("Login", loginViewModel);
                }

                return View("Login", new LoginViewModel{

                    MessageViewModel = new MessageViewModel{

                        SuccessMessages = new List<string>() {"ایمیل شما تایید شد میتوانید وارد شوید."}
                    } 
                });

            }catch(Exception e){

                return View("Login", new LoginViewModel{

                    MessageViewModel = new MessageViewModel{

                        SuccessMessages = new List<string>() {"اشکالی در فعال سازی اکانت شما ایجاد شد."}
                    } 
                });
                
            }



        }
    }
}
