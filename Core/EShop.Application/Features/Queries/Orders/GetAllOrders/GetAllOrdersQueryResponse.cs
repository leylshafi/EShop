using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Orders.GetAllOrders
{
	public class GetAllOrdersQueryResponse
	{
		public int TotalCount { get; set; }
		public object Orders { get; set; }
	}
}
