using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _dbContext;

    public UsersController(DataContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _dbContext.Users.ToListAsync();

        return users; 
    }

    [HttpGet("{id}")] // /api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }
}
