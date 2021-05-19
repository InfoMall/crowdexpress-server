using AutoMapper;
using CrowdExpress.Controllers.Generic;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository.Contract;

namespace CrowdExpress.Controllers
{
    public class NewslettersController : PkIntGenericController<Newsletter, NewsletterViewModel, NewsletterDTO>
    {
        public NewslettersController(INewsletterRepository repo, IMapper mapper) : base(repo, mapper) { }
    }
}
