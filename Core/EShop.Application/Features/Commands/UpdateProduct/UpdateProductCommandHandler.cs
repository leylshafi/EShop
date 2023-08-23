using EShop.Application.Features.Commands.AddProduct;
using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IProductWriteRepository repository;
    private readonly IProductReadRepository ReadRepository;

    public UpdateProductCommandHandler(IProductWriteRepository repository, IProductReadRepository readRepository)
    {
        this.repository = repository;
        ReadRepository = readRepository;
    }

     async Task<UpdateProductCommandResponse> IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>.Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await ReadRepository.GetAsync(request.Id.ToString());
        
        product.Name = request.Name;
        product.Description = request.Desc;
        product.Price = request.Price;
        product.Stock = request.Stock;

        repository.Update(product);
        await repository.SaveChangesAsync();

        return new();
    }
}
