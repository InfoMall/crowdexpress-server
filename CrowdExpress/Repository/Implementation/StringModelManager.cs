using AuthWebApi.Contract;
using AuthWebApi.Repository.Generics;
using CrowdExpress.Data;
using CrowdExpress.Models;
using Microsoft.AspNetCore.Http;

namespace CrowdExpress.Repository
{
    public class StringModelManager<TModel>: ModelManager<TModel, User, string>, IStringManager<TModel>
        where TModel : class, IModelPkString, new()
    {
        public StringModelManager(CrowdExpressDbContext context,
            IHttpContextAccessor httpContext) : base(context, httpContext)
        {}
    }
}
