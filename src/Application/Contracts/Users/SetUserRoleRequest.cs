using Domain.Enums;

namespace Application.Contracts.Users;

public record SetUserRoleRequest
{
    [Required]
    [EnumDataType(typeof(Role))]
    public Role Role { get; set; }
}
