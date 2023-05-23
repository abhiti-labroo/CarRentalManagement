using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories
{   public interface IRentalCarRepository
    {
        RentalCar GetRentalCar(int rentalCarId);
        IEnumerable<RentalCar> GetAllRentalCars();
        IEnumerable<RentalCar> GetRentalCarsByRental(int rentalId);
        IEnumerable<RentalCar> GetRentalItemsByCar(int carId);
        void AddRentalCar(RentalCar rentalCar);
        void UpdateRentalCar(RentalCar rentalCar);
        void DeleteRentalCar(RentalCar rentalItem);
        bool RentalCarExists(int rentalCarId);
        void Save();
    }
}
