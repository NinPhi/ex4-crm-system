namespace Application.Features.Users.EditUserBlock;

public record EditUserBlockCommand(long UserId, bool IsBlocked) : IRequest<bool>;
