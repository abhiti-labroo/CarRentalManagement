using CarRentalManagement.CarService.BusinessUnitLayer.Models;
using CarRentalManagement.CarService.DataAcessLayer.Models;
using CarRentalManagement.CarService.DataAcessLayer.Repositories;

namespace CarRentalManagement.CarService.BusinessLayer.Services
{
    public class CarS:ICarS
    {
        private readonly ICarRepository _carRepository;
        public CarS(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IEnumerable<CarDto> GetCars()
        {
            var car = _carRepository.GetAllCars();
            return car.Select(c => new CarDto
            {
                CarId = c.CarId,
                CarType = c.CarType,
                CarBrand = c.CarBrand,
                CarModel = c.CarModel,
                BuyDate = c.BuyDate,
                BuyCost = c.BuyCost,
                RentCostPerDay = c.RentCostPerDay,
                RentCostPerHour = c.RentCostPerHour,
                RentCostPerWeek = c.RentCostPerWeek,
                Inventory = c.Inventory
            });
        }
        public CarDto GetCarById(int carId)
        {
            var car = _carRepository.GetCar(carId);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            return new CarDto
            {
                CarId = car.CarId,
                CarType = car.CarType,
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                BuyDate = car.BuyDate,
                BuyCost = car.BuyCost,
                RentCostPerHour = car.RentCostPerHour,
                RentCostPerDay = car.RentCostPerDay,
                RentCostPerWeek = car.RentCostPerWeek,
                Inventory = car.Inventory
            };
        }
        public void AddCar(CarDto carDto)
        {
            var car = new Car
            {
                CarId = carDto.CarId,
                CarType = carDto.CarType,
                CarBrand = carDto.CarBrand,
                CarModel = carDto.CarModel,
                BuyDate = carDto.BuyDate,
                BuyCost = carDto.BuyCost,
                RentCostPerHour = carDto.RentCostPerHour,
                RentCostPerDay = carDto.RentCostPerDay,
                RentCostPerWeek = carDto.RentCostPerWeek,
                Inventory = carDto.Inventory
            };
            _carRepository.AddCar(car);
            _carRepository.Save();
        }
        public void UpdateCar(CarDto carDto)
        {
            var car = _carRepository.GetAllCars();
            _carRepository.UpdateCar(car);
            _carRepository.Save();
        }
        public void DeleteCar(int carId)
        {
            var car = _carRepository.GetCar(carId);
            _carRepository.DeleteCar(car);
            _carRepository.Save();
        }
    }
}
