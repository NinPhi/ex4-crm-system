using EX4_CRM.Enums;
using System.ComponentModel.DataAnnotations;

namespace EX4_CRM.Entities;

public class User
{
    public long Id { get; set; }

    [StringLength(300)]
    public string? FullName { get; set; }

    [StringLength(200)]
    public required string Email { get; set; }

    [StringLength(200)]
    public required string PasswordHash { get; set; }

    public required Role Role { get; set; }

    public DateTime? BlockedOn { get; set; }
}
