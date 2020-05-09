using CompanyBroker.Data;

namespace CompanyBroker.Web.Controllers
{
    public partial class LoginController
    {
        public class CreateAccountResponse
        {
            public int AccountId { get; set; }
            public int CompanyId { get; set; }
            public string Username { get; set; }

            public CreateAccountResponse(Account account)
            {
                AccountId = account.Id;
                CompanyId = account.CompanyId;
                Username = account.Username;
            }
        }
    }
}