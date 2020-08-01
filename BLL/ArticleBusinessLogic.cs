using System.Collections.Generic;
using System.Threading.Tasks;
using loppinja.Common.DAL;
using loppinja.Common.Interfaces.Business;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.BLL
{
    public class ArticleBusinessLogic : BaseBusinessLogic<Article>, IArticleBusinessLogic
    {
        public ArticleBusinessLogic(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateArticle(Article article){
            
            await this._unitOfWork.ArticleRepository.InsertAsync(article);

            var result = await this._unitOfWork.Save();

            return result > 0;
        }

        public IList<Article> GetListOfArticlesByPaging(PagingParameterModel pagination)
        {
            return _unitOfWork.ArticleRepository.GetListByPagination(pagination);
        }

        public async Task<Article> GetSingleArticleById(int id)
        {
            return await _unitOfWork.ArticleRepository.GetByID(id);
        }
    }
}