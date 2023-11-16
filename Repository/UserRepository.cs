using AuthenticationAndAuthorization.Helpers;
using AuthenticationAndAuthorization.Models;

namespace AuthenticationAndAuthorization.Repository
{
    public class UserRepository
    {
        private readonly JwtAuthenticationSettings _jwtAuthenticationSettings;
        private List<User> _users;
        private User _user = new();

        public UserRepository(JwtAuthenticationSettings jwtAuthenticationSettings)
        {
            _users = new List<User>() {
                new User(){
                    Id = new Guid(),
                    UserName = "Admin",
                    Nombre = "Luis",
                    Apellido = "Hernandez",
                    Email = "admin@mail.com",
                    Password = "12321",
                    Genero = "Masculino",
                    Role = new List<string>() { "Administrator", "SuperAdmin" }
                },
                new User(){
                    Id = new Guid(),
                    UserName = "User1",
                    Nombre = "Liz",
                    Apellido = "Herrera",
                    Email = "liz@mail.com",
                    Password = "12321",
                    Genero = "Femenino",
                    Role = new List<string>() { "User" }
                }
            };
            _jwtAuthenticationSettings = jwtAuthenticationSettings;

        }

        public User Get(UsuarioLogin user)
        {
            if (user != null)
            {
                var result = _users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (result != null)
                {
                    result.Token = JwtHelper.GenerarToken(result, _jwtAuthenticationSettings);
                    return result;
                }
            }

            throw new Exception("No se encontro el usuario");
        }
        public User New(User user)
        {
            var result = _users.FirstOrDefault(x => x.Email == user.Email);
            if(result != null)
                throw new Exception($"Ya existe un suario con el correo: '{user.Email}'");

            user.Id = Guid.NewGuid();
            user.Token = JwtHelper.GenerarToken(user, _jwtAuthenticationSettings);
            _users.Add(user);

            return user;
        }

    }
}
