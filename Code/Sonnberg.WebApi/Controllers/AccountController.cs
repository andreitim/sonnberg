using Microsoft.AspNetCore.Mvc;
using Sonnberg.Persistance.Entities;
using Sonnberg.Persistance.Repositories;
using Sonnberg.WebApi.Dtos;
using Sonnberg.WebApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sonnberg.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly ITokenService _tokenService;

        public AccountController(IUnitOfWork unitOfWork, ITokenService tokenService)
            : base(unitOfWork)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExistsAsync(registerDto.Username))
                return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var user = new SonnUser
            {
                Username = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveAsync();

            var userDto = new UserDto { Username = user.Username, Token = _tokenService.CreateToken(user) };
            return base.Ok(userDto);
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var users = await GetUsersAsync(loginDto.Username);
            var user = users.SingleOrDefault();

            if (user == null)
                return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (!computedHash.SequenceEqual(user.PasswordHash))
                return Unauthorized("Invalid password");

            var userDto = new UserDto { Username = user.Username, Token = _tokenService.CreateToken(user) };
            return base.Ok(userDto);

        }

        private async Task<bool> UserExistsAsync(string username)
        {
            var users = await GetUsersAsync(username);
            return users.Any();
        }

        private async Task<IReadOnlyCollection<SonnUser>> GetUsersAsync(string username)
        {
            return await _unitOfWork.Users.FindAsync(u => string.Equals(u.Username, username));
        }
    }
}
