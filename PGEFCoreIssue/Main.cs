using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PGEFCoreIssue;

public class Main
{
    private readonly DataContext _context;

    public Main(DataContext context)
    {
        _context = context;
    }

    public async Task Run()
    {
        await _context.Database.MigrateAsync();
    }
}
