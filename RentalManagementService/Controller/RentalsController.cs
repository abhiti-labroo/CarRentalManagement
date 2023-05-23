using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;
using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.RentalManagementService.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("{rentalId}")]
        public ActionResult<RentalDto> GetRental(int rentalId)
        {
            var rental = _rentalService.GetRental(rentalId);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RentalDto>> GetAllRentals()
        {
            var rentals = _rentalService.GetAllRentals();
            return Ok(rentals);
        }

        [HttpGet("byCar/{carId}")]
        public ActionResult<IEnumerable<RentalDto>> GetRentalsByCar(int carId)
        {
            var rentals = _rentalService.GetRentalsByCar(carId);
            return Ok(rentals);
        }

        [HttpGet("byCustomer/{customerId}")]
        public ActionResult<IEnumerable<RentalDto>> GetRentalsByCustomer(int customerId)
        {
            var rentals = _rentalService.GetRentalsByCustomer(customerId);
            return Ok(rentals);
        }

        [HttpGet("byPaymentStatus/{paymentStatus}")]
        public ActionResult<IEnumerable<RentalDto>> GetRentalsByPaymentStatus(string paymentStatus)
        {
            var rentals = _rentalService.GetRentalsByPaymentStatus(paymentStatus);
            return Ok(rentals);
        }

        [HttpPost]
        public ActionResult AddRental(RentalDto rentalDto)
        {
            _rentalService.AddRental(rentalDto);
            return CreatedAtAction(nameof(GetRental), new { rentalId = rentalDto.RentalId }, rentalDto);
        }

        [HttpPut("{rentalId}")]
        public IActionResult UpdateRental(int rentalId, RentalDto rentalDto)
        {
            if (rentalId != rentalDto.RentalId)
            {
                return BadRequest();
            }
            try
            {
                _rentalService.UpdateRental(rentalDto);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();}
        [HttpDelete("{rentalId}")]
        public IActionResult DeleteRental(int rentalId){
            try
            {
                _rentalService.DeleteRental(rentalId);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }}}