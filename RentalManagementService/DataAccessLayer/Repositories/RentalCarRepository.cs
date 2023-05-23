using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories  
{
    public class RentalCarRepository : IRentalCarRepository
    {
        private readonly RentalDbContext _context;
        public RentalCarRepository(RentalDbContext context)
        {
            _context = context;
        }
        public RentalCar GetRentalCar(int rentalCarId)
        {

            var getRental = _context.RentalCars.FirstOrDefault(r => r.RentalCarId == rentalCarId);

            if (getRental == null)
            {
                throw new ArgumentException("No Rental item found with this Id");
            }
            return getRental;
        }
        public IEnumerable<RentalCar> GetAllRentalCars()
        {
            return _context.RentalCars.ToList();
        }
        public IEnumerable<RentalCar> GetRentalCarsByRental(int rentalId)
        {
            return _context.RentalCars.Where(r => r.RentalId == rentalId).ToList();
        }
        public IEnumerable<RentalCar> GetRentalItemsByCar(int carId)
        {
            return _context.RentalCars.Where(r => r.CarId == carId).ToList();
        }
        public void AddRentalCar(RentalCar rentalcar)
        {
            _context.RentalCars.Add(rentalcar);
        }
        public void UpdateRentalCar(RentalCar rentalcar)
        {
            _context.Entry(rentalcar).State = EntityState.Modified;
        }
        public void DeleteRentalCar(RentalCar rentalCar)
        {
            _context.RentalCars.Remove(rentalCar);
        }
        public bool RentalCarExists(int rentalCarId)
        {
            return _context.RentalCars.Any(r => r.RentalCarId == rentalCarId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
