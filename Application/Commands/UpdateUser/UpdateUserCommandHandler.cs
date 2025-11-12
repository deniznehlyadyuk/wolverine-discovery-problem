using WolverineMediatrExample.Domain;
using WolverineMediatrExample.Infrastructure;

namespace WolverineMediatrExample.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler
{
    public User? Handle(UpdateUserCommand command)
    {
        var user = InMemoryUsers.Users.FirstOrDefault(u => u.Id == command.Id);
        if (user is null) return null;

        var updated = user with { Name = command.Name, Email = command.Email };
        InMemoryUsers.Users.Remove(user);
        InMemoryUsers.Users.Add(updated);
        return updated;
    }
}