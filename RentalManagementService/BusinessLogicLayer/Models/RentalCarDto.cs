namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models
{
    public class RentalCarDto
    {
        public int RentalCarId { get; set; }
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public string RentalCarType { get; set; } = string.Empty;
        public int RentalCarQuantity { get; set; }
        public decimal RentalCarPrice { get; set;}
        public decimal TotalRentalCarAmount { get; set; }
    }
}
