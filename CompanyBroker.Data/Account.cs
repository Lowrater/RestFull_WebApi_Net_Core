using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBroker.Data
{
    //public class AccountCompany
    //{
    //    [ForeignKey(nameof(Company))]
    //    public int CompanyId { get; set; }

    //    public Company Company { get; set; }

    //    [ForeignKey(nameof(Account))]
    //    public int AccountId { get; set; }

    //    public Account Account { get; set; }
    //}

    public class Account
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool Active { get; set; }

        public string Email { get; set; }
    }
}
