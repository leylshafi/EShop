using EShop.Application.Features.Queries.Products.GetProductById;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Customers.GetCustomerById
{
	public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQueryRequest, GetCustomerQueryResponse>
	{
		private readonly ICustomerReadRepository repository;

		public GetCustomerQueryHandler(ICustomerReadRepository repository)
		{
			this.repository = repository;
		}

		public async Task<GetCustomerQueryResponse> Handle(GetCustomerQueryRequest request, CancellationToken cancellationToken)
		{
			var customer = await repository.GetAsync(request.Id.ToString());

			return new GetCustomerQueryResponse() { Customer = customer };
		}
	}
}
