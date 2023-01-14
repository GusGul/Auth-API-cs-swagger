namespace Auth_API_1.DTOs
{
    public record AdministradorJwtDTO
    {
        public int Id { get; set; }
        public string Login { get; set; } = default!;
        public string Regra { get; set; } = default!;
        public DateTime Expiracao { get; set; } = default!;
    }
}
