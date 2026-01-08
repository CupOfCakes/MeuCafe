namespace Application.UseCases.Clients.Create;

public class ClientCreatedDTO{
    public string URL = string.Empty;

    public ClientCreatedDTO(string url)
    {
        URL = url;
    }
}