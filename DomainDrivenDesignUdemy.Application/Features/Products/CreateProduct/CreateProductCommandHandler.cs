using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Products;
using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.CreateAsync(
                request.Name,
                request.Quantity,
                request.Amount,
                request.Currency,
                request.CategoryId,
                cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
