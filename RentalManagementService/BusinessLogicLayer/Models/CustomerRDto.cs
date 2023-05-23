namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models
{
    public class CustomerRDto
    {
        public int CusId { get; set; }
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
    }
}
