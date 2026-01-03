using System.Reflection.Metadata;
using Domain.Entities;

namespace Domain.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllAsync();
}