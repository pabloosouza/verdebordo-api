using VerdeBordo.API.Models;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.API.Services.Responses;
using VerdeBordo.Domain.Entities;
using VerdeBordo.Infra.Persistence.Repository.Interfaces;

namespace VerdeBordo.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public GetCustomerResponse Add(AddCustomerInputModel model)
        {
            var customer = new Customer(model.Name, model.Contact);

            _customerRepository.Add(customer);

            return GetCustomerResponse.Map(customer);
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

        public List<GetAllCustomerResponse> GetAll()
        {
            var customers = _customerRepository.GetAll();

            var response = new List<GetAllCustomerResponse>();

            foreach (var customer in customers)
            {
                if (!customer.IsDeleted)
                {
                    response.Add(GetAllCustomerResponse.Map(customer));
                }
            }

            return response;
        }

        public GetCustomerResponse GetById(Guid id)
        {
            var customer = GetCustomerById(id);

            if (customer is null)
            {
                return null;
            }

            var response = GetCustomerResponse.Map(customer);

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
