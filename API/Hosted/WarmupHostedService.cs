using Application.Repositories;

namespace MeuCafe.Hosted;

public class WarmupHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public WarmupHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var warmup = scope.ServiceProvider.GetRequiredService<IWarmupService>();

        await warmup.ExecuteAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) 
        => Task.CompletedTask;
}