using System.Collections.Generic;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;
using loppinja.Models.Domains;

namespace loppinja.Common.DAL 
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
         IList<Article> GetListByPagination(PagingParameterModel pagination);
    }
}