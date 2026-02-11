using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class SystemRepository : IWarmupService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public SystemRepository(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ExecuteAsync()
        {
            var tasks = new List<Task>
            {
                WarmupTableAsync<Client>(),
                WarmupTableAsync<Payment>(),
                RunRawSqlWarmupAsync("SELECT 1")
            };

            await Task.WhenAll(tasks);
        }

        private async Task WarmupTableAsync<TEntity>()
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Set<TEntity>()
                .AsNoTracking()
                .TagWith($"Warmup {typeof(TEntity).Name}")
                .FirstOrDefaultAsync();
        }

        private async Task RunRawSqlWarmupAsync(string command)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.ExecuteSqlRawAsync(command);
        }
    }
}
