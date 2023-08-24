using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Customers.GetCustomerById
{
	public class GetCustomerQueryRequest:IRequest<GetCustomerQueryResponse>
	{
		public Guid Id { get; set; }
	}
}
