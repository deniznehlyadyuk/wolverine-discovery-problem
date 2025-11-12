using Microsoft.AspNetCore.Mvc;
using Wolverine;
using WolverineMediatrExample.Application.Commands.CreateUser;
using WolverineMediatrExample.Application.Commands.DeleteUser;
using WolverineMediatrExample.Application.Commands.UpdateUser;
using WolverineMediatrExample.Application.Queries.GetUser;
using WolverineMediatrExample.Contract;
using WolverineMediatrExample.Domain;

namespace WolverineMediatrExample.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IMessageBus messageBus) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var user = await messageBus.InvokeAsync<User>(new CreateUserCommand(request.Name, request.Email));
        
        return Created($"/users/{user.Id}", new GetUserResponse(user.Id, user.Name, user.Email));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequest request)
    {
        var updated = await messageBus.InvokeAsync<User?>(new UpdateUserCommand(id, request.Name, request.Email));
        
        return updated is null ? NotFound() : Ok(new GetUserResponse(updated.Id, updated.Name, updated.Email));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var deleted = await messageBus.InvokeAsync<bool>(new DeleteUserCommand(id));
        
        return deleted ? NoContent() : NotFound();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await messageBus.InvokeAsync<User?>(new GetUserQuery(id));
        
        return user is null ? NotFound() : Ok(new GetUserResponse(user.Id, user.Name, user.Email));
    }
}