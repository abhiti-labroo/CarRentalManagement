using CarRentalManagement.PaymentService.DataAcLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace CarRentalManagement.PaymentService.DataAcLayer.Repositories
{public interface IPayementRepos
    {
        Payment GetPayment(int paymentId);
        IEnumerable<Payment> GetAllPayments();
        IEnumerable<Payment> GetPaymentsByRental(int rentalId);
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(Payment payment);
        bool PaymentExists(int paymentId);
        void Save();}}
