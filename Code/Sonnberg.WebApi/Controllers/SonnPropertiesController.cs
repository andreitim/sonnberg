using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sonnberg.Persistance.Entities;
using Sonnberg.Persistance.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sonnberg.WebApi.Controllers
{
    public class SonnPropertiesController : ApiController
    {
        public SonnPropertiesController(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<SonnUser>>> GetSonnProperties()
        {
            var users = await _unitOfWork.Properties.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SonnUser>> GetSonnProperty(int id)
        {
            var user = await _unitOfWork.Properties.GetAsync(id);
            return Ok(user);
        }
    }
}
