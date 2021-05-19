using AuthWebApi.Contract;
using AuthWebApi.Repository.Generics;
using CrowdExpress.Models;

namespace CrowdExpress.Repository
{
    public interface IStringManager<TModel> : IModelManagerForString<TModel, User>
        where TModel : class, IModelPkString, new()
    {
    }
}
