using Api.core.Entities;
using Api.core.Interfaces;
using Api.core.Security;
using Api.Dtos;

namespace Api.core.Services
{
    public class AuthService : IAuth
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;
        public AuthService(UserService userService , JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        
        
        public async Task<string> Login(LoginDto loginDto)
        {
            User user = _userService.FindOne(loginDto.Username);

            if (user.Password == loginDto.Password)
            {
                var token = await _jwtService.GenerateTokenAsync(user);
                return token;
            }

            throw new Exception("Username or password is wrong");
        }

        public string Register(RegisterDto registerDto)
        {
            User user = new User();
            user.Username = registerDto.Username;
            user.Password = registerDto.Password;
            user.Name = registerDto.Name;
            user.LastName = registerDto.LastName;
            var newUser = _userService.Create(user);
            return "Successfully signed up ";
        }
    }
}

