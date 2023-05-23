using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int cusId);
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        bool CustomerExists(int customerId);
        void Save();
    }
}
