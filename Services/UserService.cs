using AndaviSolutionService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AndaviSolutionService.Services
{
    public class UserService : IUserService
    {
        // Create sample users to validate against
        private List<User> _users = new List<User>()
        {
            new User{Username="admin", Password="admin@123" }
        };
        private readonly IConfiguration _configuration;
        private readonly UserDbContext _dbContext;

        public UserService(IConfiguration configuration, UserDbContext userDbContext)
        {
            _configuration = configuration;
            _dbContext = userDbContext;
        }

        public string Login(User user)
        {
            var LoginUser = _users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            if (LoginUser == null)
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }

        public int Signup(User user)
        {
            var result = _dbContext.Database
            .ExecuteSqlRaw(
                "EXEC dbo.InsertUser @Username, @Password",
                new SqlParameter("@Username", user.Username), 
                new SqlParameter("@Password", user.Password));

            return result;
        }
    }
}
