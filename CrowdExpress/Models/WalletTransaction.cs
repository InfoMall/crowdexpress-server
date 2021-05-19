using AuthWebApi.Contract;
using AuthWebApi.Model;
using CrowdExpress.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class WalletTransaction : Audit, IModelPkString
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public WalletTransactionType WalletTransactionType { get; set; }
        public double Amount { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public string UserId { get; set; }
    }

    namespace DTOs
    {
        public class WalletTransactionDTO
        {
            public string Id { get; set; }
            public double Amount { get; set; }
            public WalletTransactionType WalletTransactionType { get; set; }
            public virtual UserDTO User { get; set; }
            public string UserId { get; set; }
        }
    }

    namespace ViewModels
    {
        public class WalletTransactionViewModel
        {
            public double Amount { get; set; }
            public string UserId { get; set; }
            public WalletTransactionType WalletTransactionType { get; set; }
        }
    }
}
