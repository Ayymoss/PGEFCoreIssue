using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PGEFCoreIssue;

public static class Setup
{
    public const string ConnectionString = "changeme";
    public static async Task Main()
    {
        var serviceCollection = new ServiceCollection()
            .AddSingleton<Main>();

        serviceCollection.AddDbContext<DataContext>(o =>
        {
            o.UseNpgsql(ConnectionString);
            o.EnableSensitiveDataLogging();
        });

        await serviceCollection
            .BuildServiceProvider()
            .GetRequiredService<Main>().Run();
    }
}
