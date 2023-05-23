using CarRentalManagement.RentalManagementService.DataAccessLayer.Data;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories.CustomerRepository;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories
{
        public class CustomerRepository : ICustomerRepository
        {
            private readonly RentalDbContext _context;
            public CustomerRepository(RentalDbContext context)
            {
                _context = context;
            }
            public Customer GetCustomer(int cusId)
            {
                var getCustomer = _context.Customers.FirstOrDefault(c => c.CusId == cusId);

                if (getCustomer == null)
                {
                    throw new ArgumentException("No Customer found with this Id");
                }
                return getCustomer;
            }
            public IEnumerable<Customer> GetAllCustomers()
            {
                return _context.Customers.ToList();
            }
            public void AddCustomer(Customer customer)
            {
                _context.Customers.Add(customer);
            }
            public void UpdateCustomer(Customer customer)
            {
                _context.Entry(customer).State = EntityState.Modified;
            }
            public void DeleteCustomer(Customer customer)
            {
                _context.Customers.Remove(customer);
            }
            public bool CustomerExists(int cusId)
            {
                return _context.Customers.Any(c => c.CusId == cusId);
            }
            public void Save()
            {
                _context.SaveChanges();
            }
        }
    }

