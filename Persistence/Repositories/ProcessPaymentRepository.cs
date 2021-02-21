using System.Threading.Tasks;
using filed.Domain.Models;
using filed.Domain.Repositories;
using filed.Domain.Services.PaymentGateway;
using filed.Persistence.Contexts;

namespace filed.Persistence.Repositories
{
    public class ProcessPaymentRepository : BaseRepository, IProcessPaymentRepository
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;


        public ProcessPaymentRepository(AppDbContext context, ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway, IPremiumPaymentGateway premiumPaymentGateway) : base(context)
        {
            this._cheapPaymentGateway = cheapPaymentGateway;
            this._expensivePaymentGateway = expensivePaymentGateway;
            this._premiumPaymentGateway = premiumPaymentGateway;
        }

        public async Task<PaymentState> AddProcessPaymentAsync(Payment payment)
        {
            var paymentState = new PaymentState { };
            var amount = payment.Amount;

            if (amount < 20.0)
            {
                paymentState = await _cheapPaymentGateway.AcceptPayment(payment);
            }

            else if (payment.Amount > 20 && payment.Amount < 501)
            {
                if (_expensivePaymentGateway.isAvailable())
                    paymentState = await _expensivePaymentGateway.AcceptPayment(payment);
                return
                paymentState = await _cheapPaymentGateway.AcceptPayment(payment);
            }

            else
            {
                var retry = 1;
                while (paymentState.PaymentStatus != StatusUnit.Processed && retry < 3)
                {
                    retry++;
                    paymentState = await _premiumPaymentGateway.AcceptPayment(payment);
                }
            }



            await _context.PaymentStates.AddAsync(paymentState);
            await _context.Payments.AddAsync(payment);
            return paymentState;

        }

    }
}