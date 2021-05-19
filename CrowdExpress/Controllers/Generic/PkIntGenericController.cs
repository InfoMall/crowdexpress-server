using AuthWebApi.Contract;
using AuthWebApi.Presentation;
using AutoMapper;
using CrowdExpress.Models;
using CrowdExpress.Repository;

namespace CrowdExpress.Controllers.Generic
{
    public class PkIntGenericController<TModel, TViewModel, TDTOModel> : GenericIntController<TModel, TViewModel, TDTOModel, User>
        where TModel : class, IModelPkInt, new()
        where TViewModel : class, new()
        where TDTOModel : class, new()
    {
        public PkIntGenericController(IIntManager<TModel> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
