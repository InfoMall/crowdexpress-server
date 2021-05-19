using AutoMapper;
using CrowdExpress.Controllers.Generic;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository.Contract;

namespace CrowdExpress.Controllers
{
    public class OrdersController : PkStringGenericController<Order, OrderViewModel, OrderDTO>
    {
        public OrdersController(IOrderRepository repo, IMapper mapper) : base(repo, mapper) 
        {}
    }
}
