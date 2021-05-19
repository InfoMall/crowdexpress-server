using AuthWebApi.Contract;
using AuthWebApi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class Newsletter : Audit, IModelPkInt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(maximumLength: 50)]
        public string Email { get; set; }
    }

    namespace DTOs
    {
        public class NewsletterDTO
        {
            public int Id { get; set; }
            public string Email { get; set; }
        }
    }

    namespace ViewModels
    {
        public class NewsletterViewModel
        {
            [Required]
            [EmailAddress]
            [StringLength(maximumLength: 50)]
            public string Email { get; set; }
        }
    }
}
