using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
namespace CarRentalManagement.PaymentService.DataAcLayer.Models{
    public class Payment{
        public int PaymentId { get; set; }
        public int RentalId { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public virtual Rental Rental { get; set; } = null!;
    }}
