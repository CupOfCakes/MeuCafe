using Domain.Entities;
using Domain.Repositories;
using Domain.Security;

namespace Application.UseCases.Clients.Delete;

public class DeleteClientUseCase
{
    private readonly IClientRepository _clientRepository;

    public DeleteClientUseCase(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task DeleteClientById(Guid id)
    {
        await _clientRepository.DeleteClientById(id);
    }
}

