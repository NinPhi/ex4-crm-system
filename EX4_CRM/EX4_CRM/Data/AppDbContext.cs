﻿using EX4_CRM.Entities;
using Microsoft.EntityFrameworkCore;

namespace EX4_CRM.Data;

public class AppDbContext(
    DbContextOptions<AppDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<Sale> Sales => Set<Sale>();

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
