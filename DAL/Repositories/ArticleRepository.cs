using System.Collections.Generic;
using System.Linq;
using loppinja.Common.DAL;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;
using loppinja.Models.Context;
using loppinja.Models.Domains;

namespace loppinja.DAL.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository 
    {
   
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public IList<Article> GetListByPagination(PagingParameterModel pagination)
        {
            return this.GetContext().Articles.Skip((pagination.pageNumber - 1) * pagination.pageSize).Take(pagination.pageSize).ToList();
        }

        

    }
}