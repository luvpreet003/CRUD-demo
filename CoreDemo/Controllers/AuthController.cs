using CoreDemoCore.Commands.Authentication;
using CoreDemoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CoreDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly ApiDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthController(JwtService jwtService, ApiDbContext dbContext, IConfiguration configuration)
        {
            _jwtService = jwtService;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if(user == null || !VerifyPassword(request.Password, user.Password))
            {
                return Unauthorized("Invalid user/password");
            }

            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Username);
            return Ok(new AuthResponse
            {
                Token = token,
                Username = user.Username,
                Expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"]))
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignUpRequest request)
        {
            if(await _dbContext.Users.AnyAsync(x => x.Username == request.Username))
            {
                return BadRequest("A user with that userName already exists");
            }

            var user = new UsersDTO
            {
                Username = request.Username,
                Password = HashPassword(request.Password)
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Username);

            return Ok(new AuthResponse
            {
                Token = token,
                Username = user.Username,
                Expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"]))
            });
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var hashedInput = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(
                Encoding.UTF8.GetBytes(password)));

            return hashedInput == storedHash;
        }
    }
}
