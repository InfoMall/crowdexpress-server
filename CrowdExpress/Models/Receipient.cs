using AuthWebApi.Contract;
using AuthWebApi.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class Receipient : Audit, IModelPkInt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [Phone]
        [StringLength(maximumLength: 15)]
        public string Phone { get; set; }

        [ForeignKey(nameof(InitiatorId))]
        public virtual User Initiator { get; set; }
        public string InitiatorId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }

    namespace DTOs
    {
        public class ReceipientDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public virtual UserDTO Initiator { get; set; }
            public string InitiatorId { get; set; }
            public ICollection<OrderDTO> Orders { get; set; }
        }
    }

    namespace ViewModels
    {
        public class ReceipientViewModel
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string InitiatorId { get; set; }
        }
    }
}
