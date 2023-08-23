using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommandRequest, GetProductByIdResponse>
{
    private readonly IProductReadRepository repository;

    public GetProductByIdHandler(IProductReadRepository repository)
    {
        this.repository = repository;
    }
    public async Task<GetProductByIdResponse> Handle(GetProductByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await repository.GetAsync(request.Id.ToString());


        return new GetProductByIdResponse() { Product = product };
    }
}
