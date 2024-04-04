using Application.Contracts.Users;

namespace Application.Features.Users.GetAllUsers;

internal class GetAllUsersQueryHandler :
    IRequestHandler<GetAllUsersQuery, List<UserResponse>>
{
    public async Task<List<UserResponse>> Handle(
        GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        // TODO
        throw new NotImplementedException();
    }
}
