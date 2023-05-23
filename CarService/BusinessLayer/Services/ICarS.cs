using CarRentalManagement.CarService.BusinessUnitLayer.Models;

namespace CarRentalManagement.CarService.BusinessLayer.Services
{
    public interface ICarS
    {
        IEnumerable<CarDto> GetCars();
        CarDto GetCarById(int CarId);
        void AddCar(CarDto car_dto);
        void UpdateCar(CarDto car_dto);
        void DeleteCar(int CarId);
    }
}
