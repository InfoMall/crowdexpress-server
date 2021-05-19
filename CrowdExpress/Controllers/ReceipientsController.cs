using AutoMapper;
using CrowdExpress.Controllers.Generic;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository;

namespace CrowdExpress.Controllers
{
    public class ReceipientsController : PkIntGenericController<Receipient, ReceipientViewModel, ReceipientDTO>
    {
        public ReceipientsController(IIntManager<Receipient> repo, IMapper mapper) : base(repo, mapper) 
        {}
    }
}
