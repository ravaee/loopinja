using System.Collections.Generic;
using System.Threading.Tasks;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.Common.Interfaces.Business
{
    public interface IBaseBusinessLogic<TEntity>
    where TEntity: BaseModel
    {
        int GetEntityCount();
    }
}