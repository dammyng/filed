using System.Threading.Tasks;
using filed.Domain.Models;
using filed.Domain.Repositories;
using filed.Persistence.Contexts;
using filed.Services;
using Microsoft.EntityFrameworkCore;

namespace filed.Persistence.Repositories
{
    public class PaymentGatewayUnitOfWork : IUnitOfWork
    {                               
        private readonly AppDbContext _context;

        public PaymentGatewayUnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}