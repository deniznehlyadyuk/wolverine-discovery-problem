using WolverineMediatrExample.Contract;
using WolverineMediatrExample.Infrastructure;

namespace WolverineMediatrExample.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler
{
    public DeleteUserResponse Handle(DeleteUserCommand command)
    {
        var user = InMemoryUsers.Users.FirstOrDefault(u => u.Id == command.Id);
        
        if (user is null)
        {
            return new DeleteUserResponse(false);
        }

        InMemoryUsers.Users.Remove(user);
        
        return new DeleteUserResponse(true);
    }
}