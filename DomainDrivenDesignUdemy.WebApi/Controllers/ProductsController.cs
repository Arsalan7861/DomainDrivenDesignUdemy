using DomainDrivenDesignUdemy.Application.Features.Products.CreateProduct;
using DomainDrivenDesignUdemy.Application.Features.Products.GetAllProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesignUdemy.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediatr.Send(request);
            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);

        }
    }
}
