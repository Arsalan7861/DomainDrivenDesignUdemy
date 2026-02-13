using DomainDrivenDesignUdemy.Application.Features.Users.CreateUser;
using DomainDrivenDesignUdemy.Application.Features.Users.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesignUdemy.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UsersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _mediatr.Send(request);
            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);

        }
    }
}
