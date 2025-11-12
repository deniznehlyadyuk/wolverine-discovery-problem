namespace WolverineMediatrExample.Application.Commands.UpdateUser;

public record UpdateUserCommand(Guid Id, string Name, string Email);