namespace Application.UseCases.Clients.Create;

public class ClientCreateRequestDTO{
    public string Name{get; set;} = string.Empty;
    public string Email{get; set;} = string.Empty;
    public string Password {get; init; } = string.Empty;

}