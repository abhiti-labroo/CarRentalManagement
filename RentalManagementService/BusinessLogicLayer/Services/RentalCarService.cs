using CarRentalManagement.CarService.DataAcessLayer.Repositories;
using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories;

namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services
{
    public class RentalCarService : IRentalCarService
    {
        private readonly IRentalCarRepository _rentalCarRepository;
        private readonly ICarRepository _carRepository;
        public RentalCarService(IRentalCarRepository rentalCarRepository, ICarRepository carRepository)
        {
            _rentalCarRepository = rentalCarRepository;
            _carRepository = carRepository;
        }
        public RentalCarDto GetRentalCarItem(int rentalCarId)
        {
            var rentalItem = _rentalCarRepository.GetRentalCar(rentalCarId);
            return ToRentalItemDto(rentalItem);
        }
        public IEnumerable<RentalCarDto> GetAllRentalCars()
        {
            var rentalItems = _rentalCarRepository.GetAllRentalCars();
            return rentalItems.Select(r => ToRentalItemDto(r));
        }
        public IEnumerable<RentalCarDto> GetRentalCarsByRental(int rentalId)
        {
            var rentalItems = _rentalCarRepository.GetAllRentalCars().Where(r => r.RentalId == rentalId);
            return rentalItems.Select(r => ToRentalItemDto(r));
        }
        public IEnumerable<RentalCarDto> GetRentalItemsByCar(int carId)
        {
            var rentalItems = _rentalCarRepository.GetAllRentalCars().Where(r => r.CarId == carId);
            return rentalItems.Select(r => ToRentalItemDto(r));
        }
        public void AddRentalCar(RentalCarDto rentalItem)
        {
            var newRentalItem = new RentalCar
            {
                RentalId = rentalItem.RentalId,
                CarId = rentalItem.CarId,
                RentalCarType = rentalItem.RentalCarType,
                RentalCarQuantity = rentalItem.RentalCarQuantity,
                RentalCarPrice = rentalItem.RentalCarPrice
            };

            _rentalCarRepository.AddRentalCar(newRentalItem);
            _rentalCarRepository.Save();
        }
        public void UpdateRentalCar(RentalCarDto rentalItem)
        {
            var existingRentalItem = _rentalCarRepository.GetRentalCar(rentalItem.RentalCarId);

            if (existingRentalItem == null)
            {
                throw new InvalidOperationException($"Rental item with ID {rentalItem.RentalCarId} not found");
            }
            // Update the properties of the existing rental item entity with the properties of the DTO
            existingRentalItem.RentalCarType = rentalItem.RentalCarType;
            existingRentalItem.RentalCarQuantity = rentalItem.RentalCarQuantity;
            existingRentalItem.RentalCarPrice = rentalItem.RentalCarPrice;
            existingRentalItem.TotalRentalCarAmount = rentalItem.TotalRentalCarAmount;
            _rentalCarRepository.Save();
        }
        public void DeleteRentalCar(int rentalItemId)
        {
            var rentalItem = _rentalCarRepository.GetRentalCar(rentalItemId);

            if (rentalItem == null)
            {
                throw new InvalidOperationException($"Rental item with ID {rentalItemId} not found");
            }

            _rentalCarRepository.DeleteRentalCar(rentalItem);
            _rentalCarRepository.Save();
        }
        public bool RentalCarExists(int rentalItemId)
        {
            var rentalItem = _rentalCarRepository.GetRentalCar(rentalItemId);
            return rentalItem != null;
        }
        private RentalCarDto ToRentalItemDto(RentalCar rentalItem)
        {
            if (rentalItem == null)
            {
                throw new Exception("Rental Id not not found");
            }

            return new RentalCarDto
            {
                RentalCarId = rentalItem.RentalCarId,
                RentalId = rentalItem.RentalId,
                CarId = rentalItem.CarId,
                RentalCarType = rentalItem.RentalCarType,
                RentalCarQuantity = rentalItem.RentalCarQuantity,
                RentalCarPrice = rentalItem.RentalCarPrice,
                TotalRentalCarAmount = rentalItem.TotalRentalCarAmount
            };
        }

    }
}
