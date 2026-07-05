using EmpMgmtSystem.Domain.Entities;
namespace EmpMgmtSystem.Domain.Interfaces;

public interface IAuthRepository
{
    Task<Employee?> GetByEmailAsync(string email);
}
