using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Orders.GetOrdersById
{
	public class GetOrderQueryRequest:IRequest<GetOrderQueryResponse>
	{
		public Guid Id { get; set; }
	}
}
