using Auth.Shared.Protos.GrpcUserService;
using Grpc.Core;
using AuthContext = Auth.Infrastructure.Contexts.AuthContext;

namespace Auth.Infrastructure.gRPC;

public class UserService : Shared.Protos.GrpcUserService.UserService.UserServiceBase
{
    private readonly AuthContext _context;
    public UserService(AuthContext context)
    {
        _context = context;
    }

    public async override Task<UserResponse> GetIdByUsername(UserRequest request, Grpc.Core.ServerCallContext context)
    {
        var username = request.Username;
        
        var user = _context.Users.FirstOrDefault(x => x.Username == username);
        
        if (user == null)
        {
                throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
        }

        return new UserResponse()
        {
            Id = user.Id.ToString()
        };
    }
}