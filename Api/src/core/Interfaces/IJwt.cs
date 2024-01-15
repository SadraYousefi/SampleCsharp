using Api.core.Entities;

namespace Api.core.Interfaces;

public interface IJwt
{
    Task<string> GenerateTokenAsync(User user);
    Task<bool> ValidateTokenAsync(string token);
}