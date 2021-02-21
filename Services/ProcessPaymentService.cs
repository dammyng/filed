using System.Collections.Generic;
using System.Threading.Tasks;
using filed.Domain.Services;
using filed.Domain.Models;
using filed.Domain.Repositories;

namespace filed.Services
{
    public class ProcessPaymentService : IProcessPaymentService
    {
        private readonly IProcessPaymentRepository _processPaymentRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProcessPaymentService(IProcessPaymentRepository processPaymentRepository, IUnitOfWork unitOfWork)
        {
            this._processPaymentRepository = processPaymentRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<PaymentState> ProcessPayment(Payment payment)
        {
            var paymentStatus = await _processPaymentRepository.AddProcessPaymentAsync(payment);
            await _unitOfWork.CompleteAsync();
            return paymentStatus;
        }
    }
}