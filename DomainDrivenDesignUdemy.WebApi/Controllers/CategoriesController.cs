using DomainDrivenDesignUdemy.Application.Features.Categories.CreateCategory;
using DomainDrivenDesignUdemy.Application.Features.Categories.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesignUdemy.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CategoriesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _mediatr.Send(request);
            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);

        }
    }
}
