using WolverineMediatrExample.Infrastructure;

namespace WolverineMediatrExample.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler
{
    public bool Handle(DeleteUserCommand command)
    {
        var user = InMemoryUsers.Users.FirstOrDefault(u => u.Id == command.Id);
        if (user is null) return false;

        InMemoryUsers.Users.Remove(user);
        return true;
    }
}