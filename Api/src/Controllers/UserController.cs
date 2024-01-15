using Api.core.Entities;
using Api.core.Services;
using Microsoft.AspNetCore.Mvc;
using Api.core.Entities;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = _userService.GetAll();
        return users;
    }
    
    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        User user = _userService.Get(userId);
        return user;
    }

    [HttpPut("update")]
    public User EditUser(User user)
    {
        User result = _userService.Update(user);
        return user;
    }

    [HttpPost("create")]
    public User CreateUser(User user)
    {
        User createdUser = _userService.Create(user);
        return createdUser;
    }

    [HttpDelete("deleteUser")]
    public User DeleteUser(User user)
    {
        User deletedUser = _userService.Delete(user);
        return user; 
    }
}