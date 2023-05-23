using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Models;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories;
namespace CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services
{
    public class RentalService: IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentalCarRepository _rentalCarRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalService(IRentalRepository rentalRepository,
                             IRentalCarRepository rentalCarRepository,
                             ICustomerRepository customerRepository)
        {
            _rentalRepository = rentalRepository;
            _rentalCarRepository = rentalCarRepository;
            _customerRepository = customerRepository;
        }

        public RentalDto GetRental(int rentalId)
        {
            var rental = _rentalRepository.GetRental(rentalId);
            if (rental == null)
            {
                throw new Exception("Rental Id not not found");
            }

            var customer = _customerRepository.GetCustomer(rental.CusId);

            return new RentalDto
            {
                RentalId = rental.RentalId,
                CusId = rental.CusId,
                CarId = rental.CarId,
                RentalCarType = rental.RentalCarType,
                RentalStartdate = rental.RentalStartdate,
                RentalEnddate = rental.RentalEnddate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            };
        }
        public IEnumerable<RentalDto> GetAllRentals()
        {
            var rentals = _rentalRepository.GetAllRental();

            return rentals.Select(rental => new RentalDto
            {
                RentalId = rental.RentalId,
                CusId = rental.CusId,
                RentalCarType = rental.RentalCarType,
                RentalStartdate = rental.RentalStartdate,
                RentalEnddate = rental.RentalEnddate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            });}
        public IEnumerable<RentalDto> GetRentalsByCar(int carId)
        {
            var rentalItems = _rentalCarRepository.GetAllRentalCars()
                .Where(ri => ri.CarId == carId)
                .Select(ri => ri.RentalId)
                .Distinct();

            var rentals = _rentalRepository.GetAllRental()
                .Where(r => rentalItems.Contains(r.RentalId));
            return rentals.Select(rental => new RentalDto
            {
                RentalId = rental.RentalId,
                CusId = rental.CusId,
                RentalCarType = rental.RentalCarType,
                RentalStartdate = rental.RentalStartdate,
                RentalEnddate = rental.RentalEnddate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            });
        }

        public IEnumerable<RentalDto> GetRentalsByCustomer(int cusId)
        {
            var rentals = _rentalRepository.GetAllRental()
                .Where(r => r.CusId == cusId);

            return rentals.Select(rental => new RentalDto
            {
                RentalId = rental.RentalId,
                CusId = rental.CusId,
                RentalCarType = rental.RentalCarType,
                RentalStartdate = rental.RentalStartdate,
                RentalEnddate = rental.RentalEnddate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            });
        }
        public IEnumerable<RentalDto> GetRentalsByPaymentStatus(string paymentStatus)
        {
            var rentals = _rentalRepository.GetAllRental().Where(r => r.PaymentStatus == paymentStatus);
            var rentalDtos = new List<RentalDto>();

            foreach (var rental in rentals)
            {
                var rentalDto = new RentalDto
                {
                    RentalId = rental.RentalId,
                    CusId = rental.CusId,
                    RentalCarType = rental.RentalCarType,
                    RentalStartdate = rental.RentalStartdate,
                    RentalEnddate = rental.RentalEnddate,
                    RentalDuration = rental.RentalDuration,
                    TotalRentalAmount = rental.TotalRentalAmount,
                    PaymentStatus = rental.PaymentStatus
                };

                rentalDtos.Add(rentalDto);
            }

            return rentalDtos;
        }
        public void AddRental(RentalDto rental)
        {
            var newRental = new Rental
            {
                CusId = rental.CusId,
                RentalCarType = rental.RentalCarType,
                RentalStartdate = rental.RentalStartdate,
                RentalEnddate = rental.RentalEnddate,
                RentalDuration = rental.RentalDuration,
                TotalRentalAmount = rental.TotalRentalAmount,
                PaymentStatus = rental.PaymentStatus
            };

            _rentalRepository.AddRental(newRental);
            _rentalRepository.Save();
        }
        public void UpdateRental(RentalDto rental)
        {
            var existingRental = _rentalRepository.GetRental(rental.RentalId);
            if (existingRental == null)
            {
                throw new ArgumentException($"Rental with id {rental.RentalId} not found");
            }
            existingRental.CusId = rental.CusId;
            existingRental.RentalCarType = rental.RentalCarType;
            existingRental.RentalStartdate = rental.RentalStartdate;
            existingRental.RentalEnddate = rental.RentalEnddate;
            existingRental.RentalDuration = rental.RentalDuration;
            existingRental.TotalRentalAmount = rental.TotalRentalAmount;
            existingRental.PaymentStatus = rental.PaymentStatus;
            _rentalRepository.UpdateRental(existingRental);
            _rentalRepository.Save();
        }

        public void DeleteRental(int rentalId)
        {
            var existingRental = _rentalRepository.GetRental(rentalId);
            if (existingRental == null)
            {
                throw new ArgumentException($"Rental with id {rentalId} not found");
            }
            _rentalRepository.DeleteRental(existingRental);
            _rentalRepository.Save();
        }

        public bool RentalExists(int rentalId)
        {
            return _rentalRepository.GetRental(rentalId) != null;
        }

    }
}
