using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sonnberg.Persistance.Entities;
using Sonnberg.Persistance.Repositories;
using Sonnberg.WebApi.Dtos;
using Sonnberg.WebApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonnberg.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly ITokenService _tokenService;

        public AccountController(IUnitOfWork unitOfWork, ITokenService tokenService, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<LoggedInUserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExistsAsync(registerDto.Username))
                return BadRequest("Username is taken");

            var user = new SonnUser { Username = registerDto.Username };
            user.SetPassword(registerDto.Password);

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveAsync();

            var userDto = new LoggedInUserDto { Username = user.Username, Token = _tokenService.CreateToken(user) };
            return Ok(userDto);
        }


        [HttpPost("login")]
        public async Task<ActionResult<LoggedInUserDto>> Login(UserCredentialsDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await GetUsersAsync(loginDto.Username);
            var user = users.SingleOrDefault();

            if (user == null)
                return Unauthorized("Invalid username");

            if (!user.ValidatePassword(loginDto.Password))
                return Unauthorized("Invalid password");

            var userDto = new LoggedInUserDto { Username = user.Username, Token = _tokenService.CreateToken(user) };
            return Ok(userDto);
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
