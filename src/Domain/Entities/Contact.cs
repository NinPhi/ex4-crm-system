using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Contact
{
    public long Id { get; set; }

    public required long MarketerId { get; set; }

    [StringLength(100)]
    public required string FirstName { get; set; }

    [StringLength(150)]
    public string? MiddleName { get; set; }

    [StringLength(150)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public required string Phone { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }

    public required ContactStatus Status { get; set; }

    public User? Marketer { get; set; }
}
