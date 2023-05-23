using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;
namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services
{public interface IRentalService
    {
        RentalDto GetRental(int rentalId);
        IEnumerable<RentalDto> GetAllRentals();
        IEnumerable<RentalDto> GetRentalsByCar(int carId);
        IEnumerable<RentalDto> GetRentalsByCustomer(int cusId);
        IEnumerable<RentalDto> GetRentalsByPaymentStatus(string paymentStatus);
        void AddRental(RentalDto rental);
        void UpdateRental(RentalDto rental);
        void DeleteRental(int rentalId);
        bool RentalExists(int rentalId);
    }}
