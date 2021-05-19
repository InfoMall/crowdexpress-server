using AutoMapper;
using CrowdExpress.Controllers.Generic;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository;

namespace CrowdExpress.Controllers
{
    public class TransactionsController : PkStringGenericController<Transaction, TransactionViewModel, TransactionDTO>
    {
        public TransactionsController(IStringManager<Transaction> repo, IMapper mapper) : base(repo, mapper) 
        {}
    }
}
