using EShop.Application.Features.Queries.Customers.GetAllCustomers;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Orders.GetAllOrders
{
	public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
	{
		private readonly IOrderReadRepository repository;

		public GetAllOrdersQueryHandler(IOrderReadRepository repository)
		{
			this.repository = repository;
		}

		public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
		{
			var orders = repository.GetAll(tracking: false);
			var totalCount = orders.Count();

			var selecetedOrders = orders
						.OrderBy(p => p.CreatedTime)
						.Skip(request.Size * request.Page)
						.Take(request.Size)
						.Select(p => new
						{
							p.Address,
							p.Description,
							p.Customer,
							p.Products
						});

			return new() { Orders = selecetedOrders, TotalCount = totalCount };
		}
	}
}
