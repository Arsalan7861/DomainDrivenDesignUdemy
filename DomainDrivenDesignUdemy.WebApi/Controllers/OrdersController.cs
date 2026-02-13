using DomainDrivenDesignUdemy.Application.Features.Orders.CreateOrder;
using DomainDrivenDesignUdemy.Application.Features.Orders.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesignUdemy.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public OrdersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _mediatr.Send(request);
            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);

        }
    }
}
