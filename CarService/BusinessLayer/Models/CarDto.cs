namespace CarRentalManagement.CarService.BusinessUnitLayer.Models
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string CarType { get; set; } = string.Empty;
        public string CarBrand { get; set; } = string.Empty;
        public string CarModel { get; set; } = string.Empty;
        public DateTime BuyDate { get; set; }
        public decimal BuyCost { get; set; }
        public decimal RentCostPerHour { get; set; }
        public decimal RentCostPerDay { get; set; }
        public decimal RentCostPerWeek { get; set; }
        public int Inventory { get; set; }

    }
}
