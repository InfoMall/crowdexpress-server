using AuthWebApi.Contract;
using AuthWebApi.Repository.Generics;
using CrowdExpress.Data;
using CrowdExpress.Models;
using Microsoft.AspNetCore.Http;

namespace CrowdExpress.Repository
{
    public class IntModelManager<TModel> : ModelManager<TModel, User, int>, IIntManager<TModel>
        where TModel : class, IModelPkInt, new()
    {
       

        public IntModelManager(CrowdExpressDbContext context,
            IHttpContextAccessor httpContext) : base(context, httpContext)
        { }
    }
}
