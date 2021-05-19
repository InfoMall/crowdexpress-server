using AuthWebApi.Contract;
using AuthWebApi.Model;
using CrowdExpress.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class Order : Audit, IModelPkString
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Pickup { get; set; }
        [Required]
        [StringLength(70)]
        public string Destination { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double Amount { get; set; }

        [ForeignKey(nameof(ReceipientId))]
        public virtual Receipient Receipient { get; set; }
        public int ReceipientId { get; set; }
        public ICollection<Itinerary> Itineraries { get; set; }
        public ICollection<Transaction> Transactions { get; set; }


    }

    namespace DTOs
    {
        public class OrderDTO
        {
            public string Id { get; set; }
            public OrderStatus OrderStatus { get; set; }
            public double Amount { get; set; }
            public virtual ReceipientDTO Receipient { get; set; }
            public string ReceipientId { get; set; }
            public ICollection<ItineraryDTO> Itineraries { get; set; }
            public ICollection<TransactionDTO> Transactions { get; set; }
        }

    }

    namespace ViewModels
    {
        public class OrderViewModel
        {
            public OrderStatus OrderStatus { get; set; }
            public double Amount { get; set; }
            public string ReceipientId { get; set; }
            [Required]
            [StringLength(70)]
            public string Pickup { get; set; }
            [Required]
            [StringLength(70)]
            public string Destination { get; set; }
            public ReceipientViewModel Receipient { get; set; }
            public ICollection<ItineraryViewModel> Itineraries { get; set; }
        }
    }
}
