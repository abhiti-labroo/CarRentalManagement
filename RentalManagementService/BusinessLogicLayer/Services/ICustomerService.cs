using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;

namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services
{
    public interface ICustomerService
    {
        CustomerRDto GetCustomer(int cusId);
        IEnumerable<CustomerRDto> GetAllCustomers();
        void AddCustomer(CustomerRDto customer);
        void UpdateCustomer(CustomerRDto customer);
        void DeleteCustomer(int cusId);
        bool CustomerExists(int cusId);
    }
}
