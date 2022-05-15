using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.ViewModels;

namespace VerdeBordo.API.Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerViewModel Add(AddCustomerInputModel model);
        bool Delete(Guid id);
        List<GetAllCustomersViewModel> GetAll();
        CustomerViewModel? GetById(Guid id);
        AddressViewModel? AddAddress(Guid id, AddAddressInputModel addAddressInputModel);
        AddressViewModel? GetAddressById(Guid id);
    }
}
