using System.Collections.Generic;
using System.Threading.Tasks;
using loppinja.BLL;
using loppinja.Common.DAL;
using loppinja.Common.Interfaces.Business;
using loppinja.Common.Interfaces.Service;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.Services.ArticleServices
{
    public class BaseService<TEntity>: IBaseService<TEntity>
    where TEntity: BaseModel
    {
        private readonly IBaseBusinessLogic<TEntity> _baseBusinessLogic;

        public BaseService(IBaseBusinessLogic<TEntity> baseBusinessLogic)
        {
            this._baseBusinessLogic = baseBusinessLogic;
        }

        public int GetEntityCount()
        {
            return _baseBusinessLogic.GetEntityCount();
        }
    }
}