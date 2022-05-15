using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.API.Services.Responses;
using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence.Repositories.Interfaces;

namespace VerdeBordo.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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

        public CustomerViewModel GetById(Guid id)
        {
            var customer = GetCustomerById(id);

            if (customer is null)
            {
                return null;
            }

            var response = CustomerViewModel.Map(customer);

            return response;
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
