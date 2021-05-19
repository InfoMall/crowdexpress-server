using AutoMapper;
using CrowdExpress.Controllers.Generic;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository;

namespace CrowdExpress.Controllers
{
    public class ItinerariesController : PkIntGenericController<Itinerary, ItineraryViewModel, ItineraryDTO>
    {
        public ItinerariesController(IIntManager<Itinerary> repo, IMapper mapper) : base(repo, mapper) 
        {}
    }
}
