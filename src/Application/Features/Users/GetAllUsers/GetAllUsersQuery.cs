using Application.Contracts.Users;

namespace Application.Features.Users.GetAllUsers;

public record GetAllUsersQuery : IRequest<List<UserResponse>>;
