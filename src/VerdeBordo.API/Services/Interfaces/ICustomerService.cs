using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Responses;

namespace VerdeBordo.API.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerViewModel Add(AddCustomerInputModel model);
        bool Delete(Guid id);
        List<GetAllCustomersViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
    }
}
