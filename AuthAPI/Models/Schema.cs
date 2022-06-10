namespace AuthAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Cpf { get; set; } = String.Empty;
        public int CodigoRh { get; set; }
        public int Status { get; set; }
        public DateTime DataAcao { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public Guid UsuarioAcao { get; set; }
        public Group Group { get; set; }
    }
    public class Group
    {
        public Guid Id { get; set; }
        public string Grupos { get; set; } = String.Empty;
    }
}