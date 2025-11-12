using WolverineMediatrExample.Domain;
using WolverineMediatrExample.Infrastructure;

namespace WolverineMediatrExample.Application.Queries.GetUser;

public class GetUserQueryHandler
{
    public User? Handle(GetUserQuery query)
    {
        return InMemoryUsers.Users.FirstOrDefault(u => u.Id == query.Id);
    }
}