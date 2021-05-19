using AutoMapper;
using CrowdExpress.Controllers.Generic;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository;

namespace CrowdExpress.Controllers
{
    public class WalletTransactionsController : PkStringGenericController<WalletTransaction, WalletTransactionViewModel, WalletTransactionDTO>
    {
        public WalletTransactionsController(IStringManager<WalletTransaction> repo, IMapper mapper) : base(repo, mapper) 
        {}
    }
}
