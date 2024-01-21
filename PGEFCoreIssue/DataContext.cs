using Microsoft.EntityFrameworkCore;

namespace PGEFCoreIssue;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<EFTest> Test { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EFTest>(ent =>
        {
            ent.Property(a => a.IPAddress).IsRequired(false);
            ent.HasIndex(a => a.IPAddress);

            ent.Property(alias => alias.SearchableIPAddress)
                .HasMaxLength(255)
                .HasComputedColumnSql(
                    @"((IPAddress & 255) || '.' || ((IPAddress >> 8) & 255)) || '.' || ((IPAddress >> 16) & 255) || '.' || ((IPAddress >> 24) & 255)",
                    stored: true);
            ent.HasIndex(alias => alias.SearchableIPAddress);
        });

        base.OnModelCreating(modelBuilder);
    }
}
