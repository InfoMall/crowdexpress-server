using AuthWebApi.Exceptions;
using AuthWebApi.Model;
using AuthWebApi.Repository;
using AuthWebApi.Repository.Generics;
using CrowdExpress.Data;
using CrowdExpress.Enums;
using CrowdExpress.Models;
using CrowdExpress.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdExpress.Repository
{
    public class UserImplementationManager : UserManager<User>, IUserContractManager
    {

        public UserImplementationManager(
            CrowdExpressDbContext context,
            AuthRepository auth,
            IIntManager<ExternalLogin<User>> externalLoginManager,
            IHttpContextAccessor httpContext
            ) : base(context, auth, externalLoginManager, httpContext) { }


        public async ValueTask<LocationViewModel> GetLocationsAsync()
        {
            string[] destinations = await Item().Select(x => x.Destination).Distinct().ToArrayAsync();
            string[] locations = await Item().Select(x => x.Location).Distinct().ToArrayAsync();
            return new LocationViewModel(destinations: destinations, locations: locations);
        }

        public async ValueTask<double> GetUserBalanceAsync(string id)
        {

            if (string.IsNullOrEmpty(id)) throw new AppUserException("User id cannot be null");
            return await Item().Where(x => x.Id == id).Select(x => x.Balance).FirstOrDefaultAsync();
        }

        public async ValueTask<ICollection<Transaction>> GetUserTransactionsAsync()
        {
            string userId = UserIdFromToken();
            if(userId == null)
            {
                throw new AppUserException("No user id in token");
            }
            ICollection<Transaction> orders = await Item().Where(x => x.Id == userId).Select(x => x.Transactions).FirstOrDefaultAsync();
            return orders;
        }

        public async ValueTask UpdateUserBalanceAsync(WalletTransaction model)
        {
            if (string.IsNullOrEmpty(model.UserId)) throw new AppUserException("User id cannot be null");
            User user = await FindOneAsync(x => x.Id == model.UserId);
            if(model.WalletTransactionType == WalletTransactionType.Credit)
            {
                user.Balance +=  model.Amount;
            }
            else
            {
                user.Balance -= model.Amount;
            }
            await UpdateAsync(user);
        }
    }
}
