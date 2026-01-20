using Domain.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyPendingByClientId(Guid id)
        {
            bool pending = await _context.Payments
            .AnyAsync(p => p.SenderId == id && p.Status == Domain.Enums.PaymentStatus.PENDING);

            return pending;
        }
    }
}
