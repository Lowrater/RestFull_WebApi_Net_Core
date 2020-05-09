using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CompanyBroker.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyBroker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class LoginController : ControllerBase
    {
        private readonly CompanyBrokerContext _context;

        private readonly Random random = new Random();

        public LoginController(CompanyBrokerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> Login(LoginRequest loginRequest)
        {
            var user = await _context.Accounts.Where(a => a.Username == loginRequest.Username).SingleOrDefaultAsync();

            if (user is null)
                return false;

            return GetHash(loginRequest.Password, user.PasswordSalt).SequenceEqual(user.PasswordHash);
        }

        [HttpPost]
        public async Task<ActionResult<CreateAccountResponse>> Create(CreateAccountRequest accountRequest)
        {
            var salt = GenerateSalt(32);
            var user = new Account
            {
                CompanyId = accountRequest.CompanyId,
                Username = accountRequest.Username,
                PasswordSalt = salt,
                PasswordHash = GetHash(accountRequest.Password, salt)
            };

            _context.Accounts.Add(user);
            await _context.SaveChangesAsync();

            return new CreateAccountResponse(user);
        }

        private byte[] GetHash(string s, byte[] salt)
        {
            using (var ha = HashAlgorithm.Create("SHA256"))
                return ha.ComputeHash(salt.Concat(Encoding.UTF8.GetBytes(s)).ToArray());
        }

        private byte[] GenerateSalt(int size)
        {
            var salt = new byte[size];
            random.NextBytes(salt);
            return salt;
        }
    }
}