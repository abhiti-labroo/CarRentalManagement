using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories;

namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public CustomerRDto GetCustomer(int cusId)
        {
            var customer = _customerRepository.GetCustomer(cusId);
            return ToCustomerDto(customer);
        }
        public IEnumerable<CustomerRDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return customers.Select(c => ToCustomerDto(c));
        }
        public void AddCustomer(CustomerRDto customer)
        {
            var newCustomer = ToCustomer(customer);
            _customerRepository.AddCustomer(newCustomer);
            _customerRepository.Save();
        }
        public void UpdateCustomer(CustomerRDto customer)
        {
            var existingCustomer = _customerRepository.GetCustomer(customer.CusId);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerFirstName = customer.CustomerFirstName;
                existingCustomer.CustomerLastName = customer.CustomerLastName;
                existingCustomer.CustomerEmail = customer.CustomerEmail;
                existingCustomer.CustomerPhone = customer.CustomerPhone;
                _customerRepository.UpdateCustomer(existingCustomer);
                _customerRepository.Save();
            }
        }        public void DeleteCustomer(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            if (customer != null)
            {
                _customerRepository.DeleteCustomer(customer);
                _customerRepository.Save();
            }
        }
        public bool CustomerExists(int customerId)
        {
            return _customerRepository.GetCustomer(customerId) != null;
        }
        private CustomerRDto ToCustomerDto(Customer customer)
        {
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            var customerDto = new CustomerRDto
            {
                CusId = customer.CusId,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                CustomerEmail = customer.CustomerEmail,
                CustomerPhone = customer.CustomerPhone
            };
            return customerDto;
        }
        private Customer ToCustomer(CustomerRDto customerDto)
        {
            var customer = new Customer
            {
                CustomerFirstName = customerDto.CustomerFirstName,
                CustomerLastName = customerDto.CustomerLastName,
                CustomerEmail = customerDto.CustomerEmail,
                CustomerPhone = customerDto.CustomerPhone
            };
            return customer;
        }
    }
}
