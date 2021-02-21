using System.Collections.Generic;
using System.Threading.Tasks;
using filed.Domain.Models;

namespace filed.Domain.Repositories
{
    public interface ICheapPaymentGatewayRepository
    {
        Task SavePayment();
        Task UpdatePayment();
    }
}