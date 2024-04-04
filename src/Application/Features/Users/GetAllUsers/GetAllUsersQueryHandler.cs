using Application.Contracts.Users;

namespace Application.Features.Users.GetAllUsers;

internal class GetAllUsersQueryHandler(IUserRepository userRepository) :
    IRequestHandler<GetAllUsersQuery, List<UserResponse>>
{
    public async Task<List<UserResponse>> Handle(
        GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync();

        var response = users.Adapt<List<UserResponse>>();

        return response;
    }
}
