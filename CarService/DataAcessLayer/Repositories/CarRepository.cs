using CarRentalManagement.CarService.DataAcessLayer.Data;
using CarRentalManagement.CarService.DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.CarService.DataAcessLayer.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;
        public CarRepository(CarDbContext context)
        {
            _context = context;
        }
        public Car GetCar(int CarId)
        {
            var getCar = _context.CarsFromInventory.Find(CarId);
            if(getCar == null)
            {
                throw new Exception("No New Car Found with this Id");
            }
            return getCar;
        }
        public IEnumerable<Car> GetAllCars()
        {
            return _context.CarsFromInventory.ToList();
        }
        public IEnumerable<Car> GetAvailableCars()
        {
            return _context.CarsFromInventory.Where(c => c.Inventory > 0);
        }
        public void AddCar(Car car)
        {
            _context.CarsFromInventory.Add(car);
        }
        public void UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
        }
        public void DeleteCar(Car car)
        {
            _context.CarsFromInventory.Remove(car);
        }
        public bool CarPresent(int CarId)
        {
            return _context.CarsFromInventory.Any(c => c.CarId == CarId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateCar(IEnumerable<Car> car)
        {
            foreach (var c in car)
            {
                var existingCar = _context.CarsFromInventory.FirstOrDefault
                   (ca => ca.CarId == c.CarId && ca.CarType == c.CarType && ca.CarBrand == c.CarBrand && ca.CarType == c.CarType && ca.BuyCost == c.BuyCost && ca.BuyDate == c.BuyDate && ca.RentCostPerHour == c.RentCostPerHour
                && ca.RentCostPerWeek == c.RentCostPerWeek && ca.RentCostPerDay == c.RentCostPerDay && ca.Inventory == c.Inventory);
                if (existingCar != null)
                {
                    existingCar.CarId = c.CarId;
                    existingCar.CarType = c.CarType;
                    existingCar.CarModel = c.CarModel;
                    existingCar.CarBrand = c.CarBrand;
                    existingCar.BuyCost = c.BuyCost;
                    existingCar.BuyDate = c.BuyDate;
                    existingCar.RentCostPerHour = c.RentCostPerHour;
                    existingCar.RentCostPerWeek = c.RentCostPerWeek;
                    existingCar.RentCostPerDay = c.RentCostPerDay;
                    existingCar.Inventory = c.Inventory;
                }
            }
        }
    }
}
