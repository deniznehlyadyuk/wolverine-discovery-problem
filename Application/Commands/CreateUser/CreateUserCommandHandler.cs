using WolverineMediatrExample.Domain;
using WolverineMediatrExample.Infrastructure;

namespace WolverineMediatrExample.Application.Commands.CreateUser;

public class CreateUserCommandHandler
{
    public User Handle(CreateUserCommand command)
    {
        var user = new User(Guid.NewGuid(), command.Name, command.Email);
        InMemoryUsers.Users.Add(user);
        return user;
    }
}