using AutoMapper;
using CrowdExpress.Controllers.Generic;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository;

namespace CrowdExpress.Controllers
{
    public class ProductsController : PkIntGenericController<Product, ProductViewModel, ProductDTO>
    {
        public ProductsController(IIntManager<Product> repo, IMapper mapper) : base(repo, mapper) 
        {}
    }
}
