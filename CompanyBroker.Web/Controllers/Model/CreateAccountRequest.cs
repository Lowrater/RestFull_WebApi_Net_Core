namespace CompanyBroker.Web.Controllers
{
    public partial class LoginController
    {
        public class CreateAccountRequest
        {
            public int CompanyId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}