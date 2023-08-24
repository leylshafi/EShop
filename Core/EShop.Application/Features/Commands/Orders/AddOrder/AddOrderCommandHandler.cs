using EShop.Application.Features.Commands.Customers.AddCustomer;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Orders.AddOrder
{
	public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
	{
		private readonly IOrderWriteRepository repository;
		public AddOrderCommandHandler(IOrderWriteRepository repository)
		{
			this.repository = repository;
		}

		public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
		{
			var order = new Order
			{
				Id = Guid.NewGuid(),
				Address = request.Address,
				Description = request.Description,
				Products = request.Products,
				Customer = request.Customer,
			};
			await repository.AddAsync(order);
			await repository.SaveChangesAsync();
			return new();
		}
	}
}
