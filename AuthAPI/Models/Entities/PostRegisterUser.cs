using AuthAPI.Models;

namespace AuthAPI.Models.Entities
{
    public class PostRegisterUser
    {
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Cpf { get; set; } = String.Empty;
        public int CodigoRh { get; set; }
        public int Status { get; set; }
        public Group Group { get; set; }
    }
}
