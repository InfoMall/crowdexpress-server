using AuthWebApi.Contract;
using AuthWebApi.Presentation;
using AutoMapper;
using CrowdExpress.Models;
using CrowdExpress.Repository;

namespace CrowdExpress.Controllers.Generic
{
    public class PkStringGenericController<TModel, TViewModel, TDTOModel> : GenericStringController<TModel, TViewModel, TDTOModel, User>
        where TModel : class, IModelPkString, new()
        where TViewModel : class, new()
        where TDTOModel : class, new()
    {
        public PkStringGenericController(IStringManager<TModel> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
