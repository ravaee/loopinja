using System.Collections.Generic;
using System.Threading.Tasks;
using loppinja.Common.Interfaces.Business;
using loppinja.Common.Interfaces.Service;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.Services.ArticleServices
{
    public class ArticleService: BaseService<Article>, IArticleService
    {
        private readonly IArticleBusinessLogic _articleBusinessObject;

        public ArticleService(IArticleBusinessLogic articleBusinessLogic, IBaseBusinessLogic<Article> baseBusinessLogic)
        :base(baseBusinessLogic)
        {
            this._articleBusinessObject = articleBusinessLogic;
        }

        public async Task<bool> CreateNewArticle(Article article)
        {
            return await _articleBusinessObject.CreateArticle(article);
        }

        public IList<Article> GetArticleListByPaging(PagingParameterModel pagination)
        {
            return _articleBusinessObject.GetListOfArticlesByPaging(pagination);            
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _articleBusinessObject.GetSingleArticleById(id);
        }

    }
}