using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.GetProductById;

public class GetProductByIdCommandRequest:IRequest<GetProductByIdResponse>
{
    public Guid Id { get; set; }
}
