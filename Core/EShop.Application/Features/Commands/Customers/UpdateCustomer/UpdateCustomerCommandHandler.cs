using EShop.Application.Features.Commands.UpdateProduct;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.UpdateCustomer
{
	public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
	{
		private readonly ICustomerWriteRepository repository;
		private readonly ICustomerReadRepository ReadRepository;

		public UpdateCustomerCommandHandler(ICustomerWriteRepository repository, ICustomerReadRepository readRepository)
		{
			this.repository = repository;
			ReadRepository = readRepository;
		}
		
		public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await ReadRepository.GetAsync(request.Id.ToString());

			product.Name = request.Name;

			repository.Update(product);
			await repository.SaveChangesAsync();

			return new();
		}
	}
}
