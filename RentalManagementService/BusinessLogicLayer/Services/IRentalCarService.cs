using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;

namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services
{
    public interface IRentalCarService
    {
        RentalCarDto GetRentalCarItem(int rentalCarId);
        IEnumerable<RentalCarDto> GetAllRentalCars();
        IEnumerable<RentalCarDto> GetRentalCarsByRental(int rentalId);
        IEnumerable<RentalCarDto> GetRentalItemsByCar(int carId);
        void AddRentalCar(RentalCarDto rentalCar);
        void UpdateRentalCar(RentalCarDto rentalCar);
        void DeleteRentalCar(int rentalCarId);
        bool RentalCarExists(int rentalCarId);
    }
}
