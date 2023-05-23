using CarRentalManagement.PaymentService.BusinessLoLayer.Models;
namespace CarRentalManagement.PaymentService.BusinessLoLayer.Services{
    public interface IPaymentS{
        PaymentDto GetPayment(int paymentId);
        IEnumerable<PaymentDto> GetAllPayments();
        IEnumerable<PaymentDto> GetPaymentsByRental(int rentalId);
        PaymentDto AddPayment(PaymentDto paymentDto);
        void UpdatePayment(PaymentDto paymentDto);
        void DeletePayment(int paymentId);
        bool PaymentExists(int paymentId);}}

