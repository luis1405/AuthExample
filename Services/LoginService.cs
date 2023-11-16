using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Repository;

namespace AuthenticationAndAuthorization.Services
{
    public class LoginService
    {
        private readonly JwtAuthenticationSettings _jwtAuthenticationSettings;
        private readonly UserRepository _userRepository;

        public LoginService(JwtAuthenticationSettings jwtAuthenticationSettings, UserRepository userRepository)
        {
            _jwtAuthenticationSettings = jwtAuthenticationSettings;
            _userRepository = userRepository;
        }

        public User Login(UsuarioLogin user)
        {
            return _userRepository.Get(user);
        }

        public User Registrar(User user)
        {
            return _userRepository.New(user);
        }
    }
}
