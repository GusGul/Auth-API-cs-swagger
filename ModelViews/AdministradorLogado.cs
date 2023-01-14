namespace Auth_API_1.ModelViews
{
    public record AdministradorLogado
    {
        public int Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string Regra { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
