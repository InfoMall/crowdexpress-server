using AuthWebApi.Contract;
using AuthWebApi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class Product : Audit, IModelPkInt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Image { get; set; }
        public double Amount { get; set; }
    }

    namespace DTOs
    {
        public class ProductDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public double Amount { get; set; }
        }
    }

    namespace ViewModels
    {
        public class ProductViewModel
        {

            [Required]
            [StringLength(maximumLength: 50)]
            public string Name { get; set; }
            [Required]
            [StringLength(maximumLength: 200)]
            public string Image { get; set; }
            public double Amount { get; set; }
        }
    }
}
