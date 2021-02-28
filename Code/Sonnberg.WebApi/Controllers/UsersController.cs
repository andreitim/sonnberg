using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sonnberg.Persistance.Dtos;
using Sonnberg.Persistance.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonnberg.WebApi.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<UserDto>>> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAllWithPhotosAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(id);
            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}