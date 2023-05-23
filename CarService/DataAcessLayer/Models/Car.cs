namespace CarRentalManagement.CarService.DataAcessLayer.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarType { get; set; } = null!;
        public string CarBrand { get; set; } = null!;
        public string CarModel { get; set; } = null!;
        public DateTime BuyDate { get; set; }
        public decimal BuyCost { get; set; }
        public decimal RentCostPerHour { get; set; }
        public decimal RentCostPerDay { get; set; }
        public decimal RentCostPerWeek { get; set; }
        public int Inventory { get; set; }
    }
}
