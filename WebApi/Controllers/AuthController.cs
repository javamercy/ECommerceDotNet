using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public AuthController(UserManager<AppUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        var user = await _userManager.FindByEmailAsync(userForLoginDto.Email);

        if (user == null) return BadRequest("Invalid email or password");

        var result = await _userManager.CheckPasswordAsync(user, userForLoginDto.Password);

        if (!result) return BadRequest("Invalid email or password");

        var token = await _tokenService.GenerateToken(user);

        return Ok(new { token });
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        var userExists = await _userManager.FindByEmailAsync(userForRegisterDto.Email);

        if (userExists != null) return BadRequest("User with this email already exists");

        var user = new AppUser
        {
            Email = userForRegisterDto.Email,
            UserName = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName
        };

        var result = await _userManager.CreateAsync(user, userForRegisterDto.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        await _userManager.AddToRoleAsync(user, "Customer");
        return Created("", new { message = "User registered successfully" });
    }
}