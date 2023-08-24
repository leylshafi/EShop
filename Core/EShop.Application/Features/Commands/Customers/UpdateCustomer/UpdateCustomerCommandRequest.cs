using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.UpdateCustomer
{
	public class UpdateCustomerCommandRequest:IRequest<UpdateCustomerCommandResponse>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
