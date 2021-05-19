using AuthWebApi.Repository;
using CrowdExpress.Models;
using CrowdExpress.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdExpress.Repository
{
    public interface IUserContractManager : IUserManager<User>
    {
        ValueTask<LocationViewModel> GetLocationsAsync();
        ValueTask<ICollection<Transaction>> GetUserTransactionsAsync();
        ValueTask<double> GetUserBalanceAsync(string id);
        ValueTask UpdateUserBalanceAsync(WalletTransaction model);
    }
}
