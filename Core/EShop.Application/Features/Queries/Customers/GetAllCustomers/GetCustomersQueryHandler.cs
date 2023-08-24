using EShop.Application.Features.Queries.Products.GetAllProducts;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Customers.GetAllCustomers
{
	public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, GetCustomersQueryResponse>
	{
		private readonly ICustomerReadRepository repository;

		public GetCustomersQueryHandler(ICustomerReadRepository repository)
		{
			this.repository = repository;
		}

		public async Task<GetCustomersQueryResponse> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
		{
			var customers = repository.GetAll(tracking: false);
			var totalCount = customers.Count();

			var selecetedCustomers = customers
						.OrderBy(p => p.CreatedTime)
						.Skip(request.Size * request.Page)
						.Take(request.Size)
						.Select(p => new
						{
							p.Name,
						});

			return new(){ Customers = selecetedCustomers, TotalCount = totalCount };
		}
	}
}
