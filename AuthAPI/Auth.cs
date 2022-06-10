namespace AuthAPI
{
    public class Auth
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Cpf { get; set; } = String.Empty;
        public int CodigoRh { get; set; }
        public int Status { get; set; }

    }
}
