using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Responses;

namespace VerdeBordo.API.Services.Interfaces
{
    public interface ICustomerService
    {
        GetCustomerResponse Add(AddCustomerInputModel model);
        bool Delete(Guid id);
        List<GetAllCustomerResponse> GetAll();
        GetCustomerResponse GetById(Guid id);
    }
}
