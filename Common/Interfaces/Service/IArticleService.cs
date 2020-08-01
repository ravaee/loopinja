using System.Collections.Generic;
using System.Threading.Tasks;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.Common.Interfaces.Service
{
    public interface IArticleService: IBaseService<Article>
    {
        Task<bool> CreateNewArticle(Article article);
        IList<Article> GetArticleListByPaging(PagingParameterModel pagination);
        Task<Article> GetArticleById(int id);
    }
}