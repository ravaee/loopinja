using System.Collections.Generic;
using System.Threading.Tasks;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;

namespace loppinja.Common.Interfaces.Service
{
    public interface IBaseService<TEntity>
    where TEntity: BaseModel
    {
        int GetEntityCount();
    }
}