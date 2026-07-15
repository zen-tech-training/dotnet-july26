// File path: Ops.Application/Services/UserService.cs

using AutoMapper;
using Ops.Application.DTOs.User;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;

namespace Ops.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        if (dto.UserName != null && await _userRepository.ExistsUserNameAsync(dto.UserName, cancellationToken))
            throw new InvalidOperationException("Username already exists.");

        if (dto.Email != null && await _userRepository.ExistsEmailAsync(dto.Email, cancellationToken))
            throw new InvalidOperationException("Email already exists.");

        if (await _userRepository.ExistsMobileNumberAsync(dto.MobileNumber, cancellationToken))
            throw new InvalidOperationException("Mobile number already exists.");

        var userEntity = _mapper.Map<User>(dto);

        // TODO: Apply secure hashing algorithm before saving password
        // userEntity.Password = _passwordHasher.Hash(dto.Password);

        await _userRepository.AddAsync(userEntity, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserDto>(userEntity);
    }

    public async Task UpdateAsync(int id, UpdateUserDto dto, CancellationToken cancellationToken = default)
    {
        var userEntity = await _userRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException($"User with ID {id} not found.");

        _mapper.Map(dto, userEntity);

        _userRepository.Update(userEntity);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task PatchAsync(int id, PatchUserDto dto, CancellationToken cancellationToken = default)
    {
        var userEntity = await _userRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException($"User with ID {id} not found.");

        _mapper.Map(dto, userEntity);

        _userRepository.Update(userEntity);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var userEntity = await _userRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException($"User with ID {id} not found.");

        _userRepository.Delete(userEntity);
        await _userRepository.SaveChangesAsync(cancellationToken);
    }
}
