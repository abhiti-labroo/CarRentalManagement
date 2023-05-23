using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories
{
    public interface IRentalRepository
    {
        Rental GetRental(int rentalId);
        IEnumerable<Rental> GetAllRental();
        IEnumerable<Rental> GetRentalsByCar(int carId);
        IEnumerable<Rental> GetRentalsByCustomer(int cusId);
        IEnumerable<Rental> GetRentalsByPaymentStatus(string paymentStatus);
        void AddRental(Rental rental);
        void UpdateRental(Rental rental);
        void DeleteRental(Rental rental);
        bool RentalExists(int rentalId);
        void Save();
    }
}
