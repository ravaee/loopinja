using System;
using System.Collections.Generic;
using loppinja.Models.Context;
using loppinja.Models.Domains;
using loppinja.Models.Utilities;
using loppinja.Models.ViewModels.ActionViewModels.Articles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Controllers
{
    public class ArticleController: BaseController<ArticleController>
    {
        public ArticleController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ILogger<ArticleController> logger,
                                 ApplicationDbContext dbContext): 
                                 base(userManager, signInManager, logger, dbContext)
        {
            
        }

        [HttpGet]
        public IActionResult Index(){

            var model = new IndexViewModel();

            model.Articles = _dbContext.Articles.Select(x => ArticleDto.ToArticleDtoMap(x)).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Read(int id){

            var article = this._dbContext.Articles.Where( x => x.Id == id).SingleOrDefault();

            if(article != null){
                return View(new ReadViewModel() {
                    Article = ArticleDto.ToArticleDtoMap(article)
                });
            }

            return RedirectToAction("Index");

            
        }

        [HttpGet]
        public IActionResult Create(){

            var model = new CreateViewModel();

            model.MapViewModel = new MapViewModel(){
                items = new List<string>(){
                "خانه", "مقالات", "ایجاد مقاله جدید"
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel createViewModel){

            try{
                _dbContext.Articles.Add(new Article() {

                    Body = createViewModel.Body,
                    CreateDate = DateTime.Now,
                    Topic = createViewModel.Topic
                });

                _dbContext.SaveChanges();

            }catch(Exception e){
                
                PrintLog(LogLevel.Error ,e.Message);
            }
            
            return View();
        }
 
    }
}