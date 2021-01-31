using Microsoft.AspNetCore.Mvc;
using Sonnberg.Persistance.Entities;
using Sonnberg.Persistance.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonnberg.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<SonnUser>>> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SonnUser>> GetUser(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(id);
            return Ok(user);
        }
    }
}