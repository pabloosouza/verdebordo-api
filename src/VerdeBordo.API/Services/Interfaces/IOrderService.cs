using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.ViewModels;

namespace VerdeBordo.API.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();
        OrderViewModel? GetById(Guid id);
        OrderViewModel? Order(Guid id, AddOrderInputModel addOrderInputModel);
        void UpdateStatus(Guid id);
    }
}
