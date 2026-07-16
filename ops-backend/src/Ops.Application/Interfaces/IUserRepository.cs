// File path: Ops.Application/Interfaces/IUserRepository.cs

using Ops.Domain.Entities;

namespace Ops.Application.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<User?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<User?> GetByUserNameAsync(
        string userName,
        CancellationToken cancellationToken = default);

    Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsUserNameAsync(
        string userName,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsEmailAsync(
        string email,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsMobileNumberAsync(
        string mobileNumber,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        User user,
        CancellationToken cancellationToken = default);

    void Update(User user);

    void Delete(User user);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
