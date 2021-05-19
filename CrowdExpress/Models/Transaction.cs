using AuthWebApi.Contract;
using AuthWebApi.Model;
using CrowdExpress.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class Transaction : Audit, IModelPkString
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public string OrderId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public virtual User Agent { get; set; }
        public string AgentId { get; set; }
    }

    namespace DTOs
    {
        public class TransactionDTO
        {
            public string Id { get; set; }
            public PaymentStatus PaymentStatus { get; set; }
            public virtual OrderDTO Order { get; set; }
            public string OrderId { get; set; }
            public virtual UserDTO Agent { get; set; }
            public string AgentId { get; set; }
        }
    }

    namespace ViewModels
    {
        public class TransactionViewModel
        {
            public PaymentStatus PaymentStatus { get; set; }
            public string OrderId { get; set; }
            public string AgentId { get; set; }
        }
    }
}
