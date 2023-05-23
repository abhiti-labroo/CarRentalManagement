namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CusId { get;set; }
        public string RentalCarType { get; set; } = string.Empty;
        public DateTime RentalStartdate { get; set; }
        public DateTime RentalEnddate { get; set; }
        public int RentalDuration { get; set; }
        public decimal TotalRentalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public IEnumerable<RentalCarDto> RentalCars { get; set; } = null!;

    }
}
