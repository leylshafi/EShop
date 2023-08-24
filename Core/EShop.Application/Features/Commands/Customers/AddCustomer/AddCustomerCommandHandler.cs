using EShop.Application.Features.Commands.AddProduct;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.AddCustomer
{
	public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, AddCustomerCommandResponse>
	{
		private readonly ICustomerWriteRepository repository;
		public AddCustomerCommandHandler(ICustomerWriteRepository repository)
		{
			this.repository = repository;
		}

		public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			var customer = new Customer
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
			};

			await repository.AddAsync(customer);
			await repository.SaveChangesAsync();
			return new();
		}
	}
}
