using VerdeBordo.API.InputModels;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.API.Services.ViewModels;
using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence.Repositories.Interfaces;

namespace VerdeBordo.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CustomerService(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public CustomerViewModel Add(AddCustomerInputModel model)
        {
            var customer = new Customer(model.Name, model.Contact);

            _customerRepository.Add(customer);

            return CustomerViewModel.Map(customer);
        }

        public bool Delete(Guid id)
        {
            var customer = GetCustomerById(id);

            if (customer is null)
            {
                return false;
            }

            customer.Delete();

            _customerRepository.Delete(customer);

            return true;
        }

        public List<GetAllCustomersViewModel> GetAll()
        {
            var customers = _customerRepository.GetAll();

            var response = new List<GetAllCustomersViewModel>();

            foreach (var customer in customers)
            {
                if (!customer.IsDeleted)
                {
                    response.Add(GetAllCustomersViewModel.Map(customer));
                }
            }

            return response;
        }

        public CustomerViewModel? GetById(Guid id)
        {
            var customer = GetCustomerById(id);

            if (customer is null)
            {
                return null;
            }

            var response = CustomerViewModel.Map(customer);

            return response;
        }

        public AddressViewModel? AddAddress(Guid id, AddAddressInputModel addAddressInputModel)
        {
            var customer = GetCustomerById(id);

            if (customer is null)
            {
                return null;
            }

            var address = new Address(
                customer.Id,
                addAddressInputModel.Street,
                addAddressInputModel.Complement,
                addAddressInputModel.Sate,
                addAddressInputModel.Number,
                addAddressInputModel.City);

           _addressRepository.Add(address);

            return AddressViewModel.Map(address);
        }

        public AddressViewModel? GetAddressById(Guid id)
        {
            var address = _addressRepository.GetById(id);

            if (address is null)
            {
                return null;
            }

            return AddressViewModel.Map(address);
        }


        private Customer? GetCustomerById(Guid id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer is null || customer.IsDeleted)
            {
                return null;
            }

            return customer;
        }
    }
}
