using EShop.Application.Features.Commands.Customers.AddCustomer;
using EShop.Application.Features.Commands.Customers.UpdateCustomer;
using EShop.Application.Features.Commands.Orders.AddOrder;
using EShop.Application.Features.Commands.Orders.UpdateOrder;
using EShop.Application.Features.Queries.Customers.GetAllCustomers;
using EShop.Application.Features.Queries.Customers.GetCustomerById;
using EShop.Application.Features.Queries.Orders.GetAllOrders;
using EShop.Application.Features.Queries.Orders.GetOrdersById;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]

	public class OrderController :ControllerBase
	{
		private readonly IOrderReadRepository orderReadRepository;
		private readonly IOrderWriteRepository orderWriteRepository;
		private readonly IMediator mediator;

		public OrderController(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IMediator mediator)
		{
			this.orderReadRepository = orderReadRepository;
			this.orderWriteRepository = orderWriteRepository;
			this.mediator = mediator;
		}

		[HttpGet("getall")]
		public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQueryRequest request)
		{
			try
			{
				var response = await mediator.Send(request);
				return Ok(response);
			}
			catch (Exception)
			{
				// logging
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody] AddOrderCommandRequest request)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await mediator.Send(request);
					return StatusCode((int)HttpStatusCode.Created);
				}
				return BadRequest(ModelState);
			}
			catch (Exception)
			{
				// logging
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}


		[HttpPut("update")]
		public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest  request)
		{
			try
			{
				var response = await mediator.Send(request);
				return Ok(response);
			}
			catch (Exception)
			{
				// logging
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}

		[HttpGet("{orderId}")]
		public async Task<IActionResult> Get(Guid orderId)
		{
			try
			{
				var request = new GetOrderQueryRequest { Id = orderId };
				var order = await mediator.Send(request);

				if (order == null)
				{
					return NotFound("Order not found.");
				}

				return Ok(order);
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
			}
		}
	}
}
