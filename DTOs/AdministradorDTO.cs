namespace Auth_API_1.DTOs
{
    public record AdministradorDTO
    {
        public string Login { get; set; } = default!;

        public string Senha { get; set; } = default!;
    }
}
