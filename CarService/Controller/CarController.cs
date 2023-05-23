using CarRentalManagement.CarService.BusinessLayer.Services;
using CarRentalManagement.CarService.BusinessUnitLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.CarService.Controller
{
    [ApiController]
    [Route("/api/cars")]
    public class CarController : ControllerBase
    {
        private readonly ICarS _carService;

        public CarController(ICarS carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars = _carService.GetCars();
            return Ok(cars);
        }

        [HttpGet("{carId}")]
        public IActionResult GetCar(int carId)
        {
            var car = _carService.GetCarById(carId);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult AddCar(CarDto car)
        {
            _carService.AddCar(car);
            return CreatedAtAction(nameof(GetCar), new { carId = car.CarId }, car);
        }

        [HttpPut("{carId}")]
        public IActionResult UpdateCar(int carId, CarDto car)
        {
            if (carId != car.CarId)
            {
                return BadRequest();
            }

            _carService.UpdateCar(car);

            return NoContent();
        }

        [HttpDelete("{carId}")]
        public IActionResult DeleteCar(int carId)
        {
            var car = _carService.GetCarById(carId);

            if (car == null)
            {
                return NotFound();
            }

            _carService.DeleteCar(carId);

            return NoContent();
        }
    }
}
