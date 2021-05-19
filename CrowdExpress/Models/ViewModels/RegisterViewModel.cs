using AuthWebApi.Contract;
using CrowdExpress.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace CrowdExpress.Models.ViewModels
{
    public class RegisterViewModel : UserAbstract, IRegistrationModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
