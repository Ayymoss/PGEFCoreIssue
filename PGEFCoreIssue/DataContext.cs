using Microsoft.EntityFrameworkCore;

namespace PGEFCoreIssue;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<EFTest> Test { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EFTest>(ent =>
        {
            ent.Property(a => a.IPAddress).IsRequired(false);
            ent.HasIndex(a => a.IPAddress);

            ent.Property(alias => alias.SearchableIPAddress)
                .HasMaxLength(255)
                .HasComputedColumnSql("CASE WHEN \"IPAddress\" IS NULL THEN 'NULL'::text ELSE (\"IPAddress\" & 255)::text || '.'::text || ((\"IPAddress\" >> 8) & 255)::text || '.'::text || ((\"IPAddress\" >> 16) & 255)::text || '.'::text || ((\"IPAddress\" >> 24) & 255)::text END",
                    stored: true);
            ent.HasIndex(alias => alias.SearchableIPAddress);
        });

        base.OnModelCreating(modelBuilder);
    }
}
