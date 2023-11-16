namespace AuthenticationAndAuthorization.Models
{
    public class User : UsuarioLogin
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string Nombre { get; set; } = String.Empty; 
        public string Apellido { get; set; } = String.Empty;
        public string Genero { get; set; } = String.Empty;
        public List<string> Role { get; set; } = new List<string>();
        public string Token { get; set; } = String.Empty;
    }
}
