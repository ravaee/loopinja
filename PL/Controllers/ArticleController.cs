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
using loppinja.Common.Models.Domains;
using loppinja.Common.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.Controllers
{
    public class ArticleController: BaseController<ArticleController>
    {
        public readonly IArticleService _articleService;
        public ArticleController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ILogger<ArticleController> logger,
                                 ApplicationDbContext dbContext,
                                 IArticleService articleService): 
                                 base(userManager, signInManager, logger, dbContext)
        {
            this._articleService = articleService;
        }

        [HttpGet]
        public IActionResult Index(){

            return RedirectToAction("ListByPaging", new {pageNumber = 1, pageSize = 10});
        }

        [HttpGet]
        public async Task<IActionResult> Read(int id){

            try {
                
                var article = await this._articleService.GetArticleById(id);

                var model = new ReadViewModel(){
                    Article = article
                };

                if(article != null){

                    model.MessageViewModel.Messages.Add("متاسفانه مقاله ای با این شماره یافت نشد");
                }

                return View(model);
                
                
            } catch(Exception e) {

                var model = new IndexViewModel();
                model.MessageViewModel.Errors.Add("مشکلی هنگام دریافت اطلاعات رخ داد");

                return RedirectToAction("Index", model);
            }
        }


        [HttpGet]
        public IActionResult Create(){

            var model = new CreateViewModel();
            model.MapViewModel = new MapViewModel(){

                items = new List<string>(){
                    "خانه","مقالات","ایحاد مقاله جدید"
                }
            };
            
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel createViewModel){

            try {
                
                var result = await _articleService.CreateNewArticle(new Article {

                    Topic = createViewModel.Topic,
                    Body = createViewModel.Body,
                    CreateDate = createViewModel.CreateDate
                });

                if(!result) {

                    createViewModel.MessageViewModel.Errors.Add("مشکلی در زمان ایجاد مقاله به وجود آمد.");
                    
                } else {

                    createViewModel.MessageViewModel.SuccessMessages.Add("مقاله با موفقیت ایجاد شد بعد از بازبینی منتشر خواهد شد.");
                }

            } catch(Exception e) {
                
                createViewModel.MessageViewModel.Errors.Add(e.Message);
            }
            
            return View(createViewModel);
        }


        [HttpGet]
        public IActionResult ListByPaging(int pageNumber, int pageSize){

            try {

                var pagination = new PagingParameterModel(){
                    pageNumber = pageNumber,
                    pageSize = pageSize
                };
                
                var articles = _articleService.GetArticleListByPaging(pagination);

                int leftOverArticlesCount = (_articleService.GetEntityCount() - articles.Count) -  ((pageNumber - 1) * pageSize)  ;

                var model = new ListViewModel(){

                    Articles = articles.ToList(),
                    LeftOverCount = leftOverArticlesCount,
                    Pagination = pagination

                };

                model.MapViewModel = new MapViewModel(){
                    items = new List<string>(){
                        "خانه","مقالات","لیست مقالات"
                    }
                };

                return View(model);

            } catch(Exception e) {

                var model = new ListViewModel();
                model.MessageViewModel.Errors.Add(e.Message);
                return View(model);

            }

        }
 
    }
}