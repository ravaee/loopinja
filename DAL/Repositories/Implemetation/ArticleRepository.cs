using loppinja.DAL.Repositories.Interface;
using loppinja.Models.Context;
using loppinja.Models.Domains;

namespace loppinja.DAL.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository 
    {
   
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        
    }
}