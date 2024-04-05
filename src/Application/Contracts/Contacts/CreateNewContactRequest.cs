using Domain.Enums;

namespace Application.Contracts.Contacts;

public record CreateNewContactRequest
{
    [Required]
    [StringLength(100)]
    public string? FirstName { get; init; }

    [StringLength(150)]
    public string? MiddleName { get; init; }

    [StringLength(150)]
    public string? LastName { get; init; }

    [Required]
    [Phone]
    [StringLength(50)]
    public string? Phone { get; init; }

    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; init; }

    [Required]
    [EnumDataType(typeof(ContactStatus))]
    public ContactStatus Status { get; init; }
}