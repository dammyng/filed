using System;
using System.Threading.Tasks;
using filed.Domain.Models;
using filed.Domain.Services.PaymentGateway;

namespace filed.Services
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public PremiumPaymentGateway()
        {
        }

        public async Task<PaymentState> AcceptPayment(Payment payment)
        {
            // Just a demo time waiting
            await Task.Delay(1000);

            // Create a random payment status
            Array values = Enum.GetValues(typeof(StatusUnit));
            Random random = new Random();
            StatusUnit randomStatus = (StatusUnit)values.GetValue(random.Next(values.Length));

            // Sample payment state
            return new PaymentState
            {
                Payment = payment,
                PaymentId = payment.Id,
                PaymentStatus = randomStatus
            };
            
        }

        public bool isAvailable()
        {
            Random rng = new Random();
            bool randomBool = rng.Next(0, 2) > 0;
            return randomBool;
        }
    }
}