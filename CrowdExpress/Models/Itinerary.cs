
using AuthWebApi.Contract;
using AuthWebApi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class Itinerary : Audit, IModelPkInt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public string OrderId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }

    namespace DTOs
    {
        public class ItineraryDTO
        {
            public int Id { get; set; }
            public virtual OrderDTO Order { get; set; }
            public string OrderId { get; set; }
            public virtual ProductDTO Product { get; set; }
            public int ProductId { get; set; }
        }
    }

    namespace ViewModels
    {
        public class ItineraryViewModel
        {
            public string OrderId { get; set; }
            public int ProductId { get; set; }
        }
    }
}
