using Common.Application;
using Shop.Domain.UserAgg.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.RemoveToken;

internal class RemoveUserTokenCommandHandler : IBaseCommandHandler<RemoveUserTokenCommand, string>
{
    private readonly IUserRepository _userRepository;

    public RemoveUserTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult<string>> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId,cancellationToken);
        if (user == null)
            return OperationResult<string>.NotFound();

        var token = user.RemoveToken(request.TokenId);
        await _userRepository.Save();
        return OperationResult<string>.Success(token);
    }
}
