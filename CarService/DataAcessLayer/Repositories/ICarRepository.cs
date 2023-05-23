using CarRentalManagement.CarService.DataAcessLayer.Models;

namespace CarRentalManagement.CarService.DataAcessLayer.Repositories
{
    public interface ICarRepository
    {
        Car GetCar(int CarId);
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetAvailableCars();
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        bool CarPresent(int CarId);
        void Save();
        void UpdateCar(IEnumerable<Car> car);
    }
}
