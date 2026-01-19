using Application.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class SystemRepository : IWarmupService
    {
        private readonly AppDbContext _context;

        private async Task WarmupTableAsync<TEntiyy>
            (DbSet<TEntiyy> table) 
            where TEntiyy : class
        {
            if(await table.AnyAsync())
            {
                _ = await table.AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public SystemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync()
        {
            await _context.Database.OpenConnectionAsync();

            _ = _context.Model;

            await _context.Database.ExecuteSqlRawAsync("SELECT 1");

            await WarmupTableAsync(_context.Clients);
            await WarmupTableAsync(_context.Payments);

        }
    }
}
