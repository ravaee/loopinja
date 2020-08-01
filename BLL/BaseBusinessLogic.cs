using loppinja.Common.DAL;
using loppinja.Common.Interfaces.Business;
using loppinja.Common.Models.Domains;

namespace loppinja.BLL
{
    public class BaseBusinessLogic<TEntity>: IBaseBusinessLogic<TEntity>
    where TEntity: BaseModel
    {
        protected IUnitOfWork _unitOfWork;
        public BaseBusinessLogic(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public int GetEntityCount()
        {
            return _unitOfWork.GetRepository<TEntity>().GetModelCount();
        }
    }
}