using System.Collections.Generic;
using System.Threading.Tasks;
using filed.Domain.Models;

namespace filed.Domain.Services
{
    public interface IProcessPaymentService
    {
         Task<PaymentState> ProcessPayment(Payment payment);
    }
}