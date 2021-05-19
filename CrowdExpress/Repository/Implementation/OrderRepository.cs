using AuthWebApi.Exceptions;
using CrowdExpress.Data;
using CrowdExpress.Enums;
using CrowdExpress.Models;
using CrowdExpress.Repository.Contract;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CrowdExpress.Repository.Implementation
{
    public class OrderRepository : StringModelManager<Order>, IOrderRepository
    {


        private readonly IUserContractManager _userManager;
        private readonly IStringManager<WalletTransaction> _walletManager;
        public OrderRepository(CrowdExpressDbContext context,
                        IUserContractManager userManager,
            IStringManager<WalletTransaction> walletManager,
            IHttpContextAccessor httpContext) : base(context, httpContext)
        {
            _userManager = userManager;
            _walletManager = walletManager;
        }

        public async override ValueTask<Order> AddAsync(Order model)
        {
            if (model.Receipient == null) throw new AppUserException("Receipient cannot be null");
            double userBalance = await _userManager.GetUserBalanceAsync(model.Receipient.InitiatorId);
            if (userBalance < model.Amount) throw new AppUserException("Insufficient funds for this transaction");
            Order order = await AddAsync(model);
            WalletTransaction walletTransaction = new WalletTransaction
            {
                Amount = model.Amount,
                UserId = model.Receipient.InitiatorId,
                WalletTransactionType = WalletTransactionType.Debit
            };
            _ = await _walletManager.AddAsync(walletTransaction);
            await _userManager.UpdateUserBalanceAsync(walletTransaction);
            return order;
        }
        
    }
}
