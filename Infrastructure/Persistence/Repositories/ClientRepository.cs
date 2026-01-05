using Domain.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

   public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<string> CreateNewClient(Client client)
    {
        // implementação
        return "ok";
    }
}