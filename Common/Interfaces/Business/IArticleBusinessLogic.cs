using System.Collections.Generic;
using System.Threading.Tasks;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.Common.Interfaces.Business
{
    public interface IArticleBusinessLogic: IBaseBusinessLogic<Article>
    {
         Task<bool> CreateArticle(Article article);
         IList<Article> GetListOfArticlesByPaging(PagingParameterModel pagination);
         Task<Article> GetSingleArticleById(int id);
         
    }
}