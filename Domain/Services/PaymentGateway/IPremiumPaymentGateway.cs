using System.Collections.Generic;
using System.Threading.Tasks;
using filed.Domain.Models;
using filed.Domain.Repositories;

namespace filed.Domain.Services.PaymentGateway
{
    public interface IPremiumPaymentGateway
    {
        bool isAvailable();
        Task<PaymentState> AcceptPayment(Payment payment);
    }
}