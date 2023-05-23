using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalManagement.RentalManagementService.DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        public int CusId { get; set; }
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; }= string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; }= string.Empty;
        public string CustomerAddress { get; set; }= string.Empty;
        public ICollection<Rental> Rentals { get; set; } = null!;

    }
}
