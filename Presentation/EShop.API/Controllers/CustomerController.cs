using EShop.Application.Features.Commands.Customers.AddCustomer;
using EShop.Application.Features.Commands.Customers.UpdateCustomer;
using EShop.Application.Features.Commands.UpdateProduct;
using EShop.Application.Features.Queries.Customers.GetAllCustomers;
using EShop.Application.Features.Queries.Customers.GetCustomerById;
using EShop.Application.Features.Queries.Products.GetAllProducts;
using EShop.Application.Features.Queries.Products.GetProductById;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.ProductRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class CustomerController : ControllerBase
	{
		private readonly ICustomerReadRepository customerReadRepository;
		private readonly ICustomerWriteRepository customerWriteRepository;
		private readonly IMediator mediator;

		public CustomerController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMediator mediator)
		{
			this.customerReadRepository = customerReadRepository;
			this.customerWriteRepository = customerWriteRepository;
			this.mediator = mediator;
		}

		[HttpGet("getall")]
		public async Task<IActionResult> GetAll([FromQuery] GetCustomersQueryRequest request)
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
		public async Task<IActionResult> Add([FromBody] AddCustomerCommandRequest request)
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
		public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest request)
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

		[HttpGet("{customerId}")]
		public async Task<IActionResult> Get(Guid customerId)
		{
			try
			{
				var request = new GetCustomerQueryRequest { Id = customerId };
				var customer = await mediator.Send(request);

				if (customer == null)
				{
					return NotFound("Customer not found.");
				}

				return Ok(customer);
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
			}
		}
	}
}

