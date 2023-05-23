using CarRentalManagement.CarService.DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Models
{
    public class RentalCar
    {
        public int RentalCarId { get; set; }
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public string RentalCarType { get; set; } = string.Empty;
        public int RentalCarQuantity { get; set; }
        public decimal RentalCarPrice { get; set; }
        public decimal TotalRentalCarAmount { get; set; }
        public Rental Rental { get; set; } = null!;
        public Car Car { get; set; } = null!;
    }
}
