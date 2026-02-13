using DomainDrivenDesignUdemy.Domain.Categories;
using MediatR;

namespace DomainDrivenDesignUdemy.Application.Features.Categories.GetAllCategory
{
    public sealed record GetAllCategoryQuery() : IRequest<List<Category>>;
}
