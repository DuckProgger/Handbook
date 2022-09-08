using Handbook.Server.Services.UserService;
using Handbook.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Handbook.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var result = await userService.GetAllUsersAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var result = await userService.GetUserAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult<bool>> AddUser(User user)
    {
        var result = await userService.AddUserAsync(user);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult<User>> UpdateUser(User user)
    {
        var result = await userService.UpdateUserAsync(user);
        if(result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<ActionResult<User>> RemoveUser(int id)
    {
        var result = await userService.RemoveUserAsync(id);
        if(!result)
            return NotFound();
        return Ok(result);
    }
}