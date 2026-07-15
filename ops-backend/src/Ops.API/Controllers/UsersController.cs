// File path: Ops.API/Controllers/UsersController.cs

using Microsoft.AspNetCore.Mvc;
using Ops.Application.DTOs.User;
using Ops.Application.Interfaces;

namespace Ops.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var user = await _userService.GetByIdAsync(id, cancellationToken);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateUserDto dto,
        CancellationToken cancellationToken)
    {
        var user = await _userService.CreateAsync(dto, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = user.Id },
            user);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateUserDto dto,
        CancellationToken cancellationToken)
    {
        await _userService.UpdateAsync(
            id,
            dto,
            cancellationToken);

        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(
        int id,
        PatchUserDto dto,
        CancellationToken cancellationToken)
    {
        await _userService.PatchAsync(
            id,
            dto,
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        await _userService.DeleteAsync(
            id,
            cancellationToken);

        return NoContent();
    }
}
