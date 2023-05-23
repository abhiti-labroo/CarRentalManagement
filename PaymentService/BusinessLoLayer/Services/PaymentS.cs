using CarRentalManagement.PaymentService.BusinessLoLayer.Models;
using CarRentalManagement.PaymentService.DataAcLayer.Models;
using CarRentalManagement.PaymentService.DataAcLayer.Repositories;
namespace CarRentalManagement.PaymentService.BusinessLoLayer.Services{
    public class PaymentS : IPaymentS{
        private readonly IPayementRepos _paymentRepository;
        public PaymentS(IPayementRepos paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public PaymentDto GetPayment(int paymentId)
        {
            var payment = _paymentRepository.GetPayment(paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not not found");
            }
            return new PaymentDto
            {
                PaymentId = payment.PaymentId,
                RentalId = payment.RentalId,
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                PaymentAmount = payment.PaymentAmount,
                PaymentStatus = payment.PaymentStatus,
            };}
        public IEnumerable<PaymentDto> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            return payments.Select(payment => new PaymentDto
            {
                PaymentId = payment.PaymentId,
                RentalId = payment.RentalId,
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                PaymentAmount = payment.PaymentAmount,
                PaymentStatus = payment.PaymentStatus,
            });}
        public IEnumerable<PaymentDto> GetPaymentsByRental(int rentalId)
        {
            var payments = _paymentRepository.GetPaymentsByRental(rentalId);
            return payments.Select(payment => new PaymentDto
            {
                PaymentId = payment.PaymentId,
                RentalId = payment.RentalId,
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                PaymentAmount = payment.PaymentAmount,
                PaymentStatus = payment.PaymentStatus,

            });}
        public PaymentDto AddPayment(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                RentalId = paymentDto.RentalId,
                PaymentType = paymentDto.PaymentType,
                PaymentDate = paymentDto.PaymentDate,
                PaymentAmount = paymentDto.PaymentAmount,
                PaymentStatus = paymentDto.PaymentStatus,
            };
            _paymentRepository.AddPayment(payment);
            _paymentRepository.Save();
            paymentDto.PaymentId = payment.PaymentId;
            return paymentDto;}
        public void UpdatePayment(PaymentDto paymentDto)
        {
            var payment = _paymentRepository.GetPayment(paymentDto.PaymentId);
            if (payment == null)
            {
                return;
            }
            payment.RentalId = paymentDto.RentalId;
            payment.PaymentType = paymentDto.PaymentType;
            payment.PaymentDate = paymentDto.PaymentDate;
            payment.PaymentAmount = paymentDto.PaymentAmount;
            payment.PaymentStatus = paymentDto.PaymentStatus;
            _paymentRepository.UpdatePayment(payment);
            _paymentRepository.Save();
        }
        public void DeletePayment(int paymentId)
        {
            var payment = _paymentRepository.GetPayment(paymentId);
            if (payment == null)
            {
                return;
            }
            _paymentRepository.DeletePayment(payment);
            _paymentRepository.Save();
        }
        public bool PaymentExists(int paymentId)
        {
            return _paymentRepository.PaymentExists(paymentId);
        }}}
