using AuthWebApi.Contract;
using AuthWebApi.Presentation;
using AutoMapper;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;
using CrowdExpress.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeilaFoods.Controllers
{
    public class UsersController: AccountController<User, UserDTO, LoginViewModel, RegisterViewModel>
    {
        public UsersController(IUserContractManager repo, IEmailSender emailSender, IMapper mapper): base(repo, emailSender, mapper) {}

        [HttpGet("locations")]
        public async ValueTask<ActionResult<LocationViewModel>> GetLocationsAsync()
        {
            LocationViewModel model = await (_acc as IUserContractManager).GetLocationsAsync();
            return Ok(model);
        }

        [Authorize]
        [HttpGet("orders")]
        public async ValueTask<ActionResult<List<TransactionDTO>>> GetUserOrders()
        {
            ICollection<Transaction> model = await (_acc as IUserContractManager).GetUserTransactionsAsync();
            return Ok(_mapper.Map<ICollection<Transaction>, ICollection<TransactionDTO>>(model));
        }
    }
}
