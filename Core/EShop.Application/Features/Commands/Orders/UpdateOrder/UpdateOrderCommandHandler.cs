using EShop.Application.Repositories.OrderRepository;
using MediatR;

namespace EShop.Application.Features.Commands.Orders.UpdateOrder
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
	{
		private readonly IOrderWriteRepository repository;
		private readonly IOrderReadRepository ReadRepository;

		public UpdateOrderCommandHandler(IOrderWriteRepository repository, IOrderReadRepository readRepository)
		{
			this.repository = repository;
			ReadRepository = readRepository;
		}

		public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
		{
			var order = await ReadRepository.GetAsync(request.Id.ToString());

			order.Description=request.Description;
			order.Customer = request.Customer;
			order.Products = request.Products;
			order.Address = request.Address;
			repository.Update(order);
			await repository.SaveChangesAsync();

			return new();
		}
	}
}
