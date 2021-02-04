using Microsoft.AspNetCore.Mvc;
using Sonnberg.Persistance.Repositories;

namespace Sonnberg.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
