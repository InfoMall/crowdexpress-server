using AuthWebApi.Exceptions;
using CrowdExpress.Data;
using CrowdExpress.Models;
using CrowdExpress.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrowdExpress.Repository.Implementation
{
    public class NewsletterRepository : IntModelManager<Newsletter>, INewsletterRepository
    {
        

        public NewsletterRepository(CrowdExpressDbContext context,
            IHttpContextAccessor httpContext) : base(context, httpContext)
        { }

        public async override ValueTask<Newsletter> AddAsync(Newsletter model)
        {
            bool emailExists = await Item().AnyAsync(x => x.Email == model.Email.ToLower());
            if (emailExists) throw new AppUserException("You are an active subscriber already");
            else
            {
                model.Email = model.Email.ToLower();
                return await base.AddAsync(model);
            }
        }
        
    }
}
