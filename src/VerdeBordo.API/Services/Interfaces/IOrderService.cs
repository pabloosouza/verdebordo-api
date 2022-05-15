using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Responses;

namespace VerdeBordo.API.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();
        OrderViewModel GetById(Guid id);
        OrderViewModel Order(Guid id, AddOrderInputModel addOrderInputModel);
    }
}
