using AuthWebApi.Contract;
using AuthWebApi.Repository.Generics;
using CrowdExpress.Models;

namespace CrowdExpress.Repository
{
    public interface IIntManager<TModel> : IModelManagerForInt<TModel, User>
        where TModel : class, IModelPkInt, new()
    {
    }
}
