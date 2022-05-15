using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.API.Services.ViewModels;
using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence.Repositories.Interfaces;

namespace VerdeBordo.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public List<OrderViewModel> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var response = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                response.Add(OrderViewModel.Map(order));
            }

            return response;
        }

        public OrderViewModel? GetById(Guid id)
        {
            var order = _orderRepository.GetById(id);

            if (order is null)
            {
                return null;
            }

            return OrderViewModel.Map(order);
        }

        public OrderViewModel? Order(Guid id, AddOrderInputModel addOrderInputModel)
        {
            var customer = _customerRepository.GetById(id);

            if (customer is null)
            {
                return null;
            }

            var embroidery = new Embroidery(
                id,
                addOrderInputModel.Size,
                addOrderInputModel.Price,
                addOrderInputModel.PaymentMethod
                );

            _customerRepository.Order(embroidery);

            return OrderViewModel.Map(embroidery);
        }
    }
}
