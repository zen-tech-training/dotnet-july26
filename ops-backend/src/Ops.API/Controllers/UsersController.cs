using Microsoft.AspNetCore.Mvc;
using Ops.Application.DTOs.User;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;
using Ops.Domain.Enums;

namespace Ops.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var users =
                await _unitOfWork.Users.GetAllAsync(token);

            var userDtos = users.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Role = u.Role,
                MobileNumber = u.MobileNumber,
                Email = u.Email
            });

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken token)
        {
            var user =
                await _unitOfWork.Users.GetByIdAsync(id, token);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("by-name{userName}")]
        public async Task<IActionResult> GetByUserName(string userName, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByUserNameAsync(userName, cancellationToken);
            if (user is null) return NotFound();
            return Ok(user);
        }

        [HttpGet("by-email{email}")]
        public async Task<IActionResult> GetByEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email, cancellationToken);
            if (user is null) return NotFound();
            return Ok(user);
        }

        [HttpGet("by-mobile-number{mobileNumber}")]
        public async Task<IActionResult> GetByMobileNumber(string mobileNumber, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByMobileNumberAsync(mobileNumber, cancellationToken);
            if (user is null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateUserDto dto, CancellationToken token)
        {
            if (dto.Role == UserRole.Admin)
            {
                return BadRequest("Admin user cannot be created from this API.");
            }

            //Need Automapper - _mapper.Map<User>(dto);
            var user = new User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                Role = dto.Role,
                MobileNumber = dto.MobileNumber,
                Email = dto.Email
            };

            await _unitOfWork.Users.AddAsync(user, token);

            await _unitOfWork.SaveAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = user.Id },
                user
           );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateUserDto dto, CancellationToken cancellationToken)
        {
            if (dto.Role == UserRole.Admin)
            {
                return BadRequest("Admin user cannot be updated from this API.");
            }
            var user =
                await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);

            if (user == null)
                return NotFound();

            if (user.Role == UserRole.Admin)
            {
                return BadRequest("Admin user cannot be updated from this API.");
            }

            user.UserName = dto.UserName;
            user.Password = dto.Password;
            user.Role = dto.Role;
            user.MobileNumber = dto.MobileNumber;
            user.Email = dto.Email;

            _unitOfWork.Users.Update(user, cancellationToken);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(
            int id,
            PatchUserDto dto, CancellationToken cancellationToken)
        {
            if (dto.Role == UserRole.Admin)
            {
                return BadRequest("Admin user cannot be updated from this API.");
            }
            var user =
                await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);

            if (user == null)
                return NotFound();

            if (dto.UserName != null)
                user.UserName = dto.UserName;

            if (dto.Password != null)
                user.Password = dto.Password;

            if (user.Role != dto.Role)
                    user.Role = dto.Role;

            if (user.Role == UserRole.Admin)
            {
                return BadRequest("Admin user cannot be updated from this API.");
            }

            if (dto.MobileNumber != null)
                user.MobileNumber = dto.MobileNumber;

            if (dto.Email != null)
                user.Email = dto.Email;

            _unitOfWork.Users.Update(user, cancellationToken);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var user =
                await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);

            if (user!.Role == UserRole.Admin)
            {
                return BadRequest("Admin user cannot be deleted from this API.");
            }

            if (user == null)
                return NotFound();

            _unitOfWork.Users.Delete(user, cancellationToken);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}