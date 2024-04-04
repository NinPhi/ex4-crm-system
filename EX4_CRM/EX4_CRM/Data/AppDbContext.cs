using EX4_CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace EX4_CRM.Data;

public class AppDbContext(
    DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Lead>()
            .HasOne(s => s.Salesman)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Sale>()
            .HasOne(s => s.Salesman)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
