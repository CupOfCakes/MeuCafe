using Domain.Repositories;
using Domain.Entities;
using Domain.Exceptions;
using Application.Exceptions;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Constraints;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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

    public async Task CreateNewClient(Client client)
    {
        try
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateException ex) when
            (ex.InnerException is PostgresException { SqlState: "23505" } pgEx)
        {
            throw pgEx.ConstraintName switch
            {
                ClientConstraints.UniqueName => new UserNameAlreadyExists(),
                ClientConstraints.UniqueEmail => new EmailAlreadyInUse(),
                _ => ex
            };
        }
        
    }

    public async Task DeleteClientById(Guid id)
    {

        await using var transaction = await _context.Database.BeginTransactionAsync();

        var rowsAffected = await _context.Clients
                              .Where(c => c.Id == id)
                              .ExecuteDeleteAsync();

        if (rowsAffected == 0) throw new ClientNotFoundException();

    }
}