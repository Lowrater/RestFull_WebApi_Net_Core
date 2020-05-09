using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBroker.Data
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public bool Active { get; set; }

        public ICollection<Account> Accounts { get; set; }

       // public ICollection<AccountCompany> AccountCompanies { get; set; }
    }
}
