using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services;
using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
namespace CarRentalManagement.RentalManagementService.Controller
{
    [ApiController]
    [Route("/api/rentalitems")]
    public class RentalItemController : ControllerBase
    {
        private readonly IRentalCarService _rentalCarService;
        public RentalItemController(IRentalCarService rentalCarService)
        {
            _rentalCarService = rentalCarService;
        }
        [HttpGet("{rentalCarId}")]
        public ActionResult<RentalCarDto> GetRentalItem(int rentalCarId)
        {
            var rentalItem = _rentalCarService.GetRentalCarItem(rentalCarId);
            if (rentalItem == null)
            {
                return NotFound();
            }

            return Ok(rentalItem);
        }
        [HttpGet]
        public ActionResult<IEnumerable<RentalCarDto>> GetAllRentalItems()
        {
            var rentalItems = _rentalCarService.GetAllRentalCars();
            return Ok(rentalItems);
        }
        [HttpGet("rental/{rentalId}")]
        public ActionResult<IEnumerable<RentalCarDto>> GetRentalItemsByRental(int rentalId)
        {
            var rentalItems = _rentalCarService.GetRentalCarsByRental(rentalId);
            return Ok(rentalItems);
        }
        [HttpGet("car/{carId}")]
        public ActionResult<IEnumerable<RentalCarDto>> GetRentalItemsByBike(int carId)
        {
            var rentalItems = _rentalCarService.GetRentalItemsByCar(carId);
            return Ok(rentalItems);
        }
        [HttpPost]
        public ActionResult AddRentalItem(RentalCarDto rentalItem)
        {
            _rentalCarService.AddRentalCar(rentalItem);
            return CreatedAtAction(nameof(GetRentalItem), new { rentalItemId = rentalItem.RentalCarId }, rentalItem);
        }
        [HttpPut("{rentalCarId}")]
        public ActionResult UpdateRentalItem(int rentalCarId, RentalCarDto rentalItem)
        {
            if (rentalCarId != rentalItem.RentalCarId)
            {
                return BadRequest();
            }
            _rentalCarService.UpdateRentalCar(rentalItem);
            return NoContent();
        }
        [HttpDelete("{rentalCarId}")]
        public ActionResult DeleteRentalItem(int rentalCarId)
        {
            if (!_rentalCarService.RentalCarExists(rentalCarId))
            {
                return NotFound();
            }

            _rentalCarService.DeleteRentalCar(rentalCarId);
            return NoContent();
        }
    }
}