﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Products.GetProductById
{
	public class GetProductByIdQueryRequest:IRequest<GetProductByIdQueryResponse>
	{
		public Guid Id { get; set; }
	}
}
