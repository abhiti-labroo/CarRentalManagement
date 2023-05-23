using CarRentalManagement.CarService.DataAcessLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CusId { get; set; }
        public string RentalCarType { get; set; } = string.Empty;
        public DateTime RentalStartdate { get; set; }
        public DateTime RentalEnddate { get; set;}
        public int RentalDuration { get; set; }
        public decimal TotalRentalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public Car Car { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public ICollection<RentalCar> RentalCars { get; set; } = null!;

    }
}
