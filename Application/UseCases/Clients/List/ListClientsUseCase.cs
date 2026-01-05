using Domain.Repositories;
using Domain.Entities;

namespace Application.UseCases.Clients.List;

public class ListClientsUseCase
{
    private readonly IClientRepository _clientRepository;

    public ListClientsUseCase(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Client>> ExecuteAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return clients;
    }
}
