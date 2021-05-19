using AuthWebApi.Contract;
using AuthWebApi.Model;
using CrowdExpress.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdExpress.Models
{
    public class User: Audit, IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(maximumLength: 30)]
        public string EmailAddress { get; set; }
        public double Balance { get; set; }

        [Required]
        [StringLength(maximumLength: 64)]
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(maximumLength: 40)]
        public string Language { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Location { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Destination { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Address { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        [Phone]
        [StringLength(maximumLength: 15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string NextOfKin { get; set; }
        [Phone]
        [StringLength(maximumLength: 15)]
        public string NexOfKinPhone { get; set; }
        public bool IsVerified { get; set; }
        [StringLength(maximumLength: 300)]
        public string Picture { get; set; }
        [StringLength(maximumLength: 300)]
        public string IdCard { get; set; }
        [StringLength(maximumLength: 20)]
        public string Role { get; set; }
        [StringLength(maximumLength: 30)]
        public string FirstName { get; set; }
        [StringLength(maximumLength: 30)]
        public string SurName { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string UserName { get; set; }

        [StringLength(maximumLength: 70)]
        public string Code { get; set; }
        [StringLength(maximumLength: 50)]
        public string AccountName { get; set; }
        [StringLength(maximumLength: 15)]
        public string AccountNumber { get; set; }
        [StringLength(maximumLength: 30)]
        public string BankName { get; set; }
        public DateTime CodeIssued { get; set; }
        public DateTime VerifiedOn { get; set; }
        public DateTime CodeWillExpire { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }
        public virtual ICollection<Receipient> Receipients { get; set; }
        public virtual ICollection<ExternalLogin<User>> ExternalLogins { get; private set; } = new List<ExternalLogin<User>>();
    }

    namespace DTOs
    {
        public class UserDTO : UserAbstract, IUserDto
        {
            public string Id { get; set; }
            public string Token { get; set; }
            public bool IsVerified { get; set; }
            public string UserName { get; set; }
        }
    }

    namespace Abstract
    {
        public class UserAbstract
        {
            [Required]
            [EmailAddress]
            [StringLength(maximumLength: 30)]
            public string EmailAddress { get; set; }
            [Required]
            [StringLength(maximumLength: 40)]
            public string Language { get; set; }
            [Required]
            [StringLength(maximumLength: 50)]
            public string Location { get; set; }
            public double Balance { get; set; }
            [Required]
            [StringLength(maximumLength: 50)]
            public string Destination { get; set; }
            [Required]
            [StringLength(maximumLength: 100)]
            public string Address { get; set; }
            [Required]
            public DateTime DoB { get; set; }
            [Phone]
            [Required]
            [StringLength(maximumLength: 15)]
            public string Phone { get; set; }
            [Required]
            [StringLength(maximumLength: 100)]
            public string NextOfKin { get; set; }
            [Phone]
            [Required]
            [StringLength(maximumLength: 15)]
            public string NexOfKinPhone { get; set; }
            [StringLength(maximumLength: 300)]
            public string Picture { get; set; }
            [StringLength(maximumLength: 300)]
            public string IdCard { get; set; }
            [StringLength(maximumLength: 10)]
            public string Role { get; set; }

            [Required]
            [StringLength(maximumLength: 20)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(maximumLength: 20)]
            public string SurName { get; set; }
            public string AccountName { get; set; }
            [StringLength(maximumLength: 15)]
            public string AccountNumber { get; set; }
            [StringLength(maximumLength: 30)]
            public string BankName { get; set; }
        }
    }

}
