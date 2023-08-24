using EShop.Application.Features.Queries.Customers.GetCustomerById;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Orders.GetOrdersById
{
	public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GetOrderQueryResponse>
	{
		private readonly IOrderReadRepository repository;

		public GetOrderQueryHandler(IOrderReadRepository repository)
		{
			this.repository = repository;
		}

		public async Task<GetOrderQueryResponse> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
		{
			var order = await repository.GetAsync(request.Id.ToString());

			return new GetOrderQueryResponse() { Order = order };
		}
	}
}
