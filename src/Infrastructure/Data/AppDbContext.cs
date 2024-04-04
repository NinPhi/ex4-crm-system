﻿using Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Data;

public class AppDbContext(
    DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<Sale> Sales => Set<Sale>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var dataSeeder = Database.GetService<DataSeeder>();
        dataSeeder.Seed(modelBuilder);

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
