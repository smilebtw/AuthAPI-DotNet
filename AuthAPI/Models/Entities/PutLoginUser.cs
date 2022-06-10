namespace AuthAPI.Models.Entities
{
    public class PutLoginUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Cpf { get; set; } = String.Empty;
        public int CodigoRh { get; set; }
        public int Status { get; set; }
        public Group Group { get; set; }
    }
}
