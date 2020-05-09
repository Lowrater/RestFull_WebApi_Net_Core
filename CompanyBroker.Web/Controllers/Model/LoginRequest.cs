namespace CompanyBroker.Web.Controllers
{
    public partial class LoginController
    {
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}