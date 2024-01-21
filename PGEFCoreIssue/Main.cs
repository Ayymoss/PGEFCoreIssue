using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PGEFCoreIssue;

public class Main(DataContext context)
{
    public async Task Run()
    {
        await context.Database.MigrateAsync();
    }
}
