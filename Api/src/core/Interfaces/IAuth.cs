using Api.Dtos;

namespace Api.core.Interfaces;

public interface IAuth
{
    public Task<string> Login(LoginDto loginDto);

    public string Register(RegisterDto registerDto);
}