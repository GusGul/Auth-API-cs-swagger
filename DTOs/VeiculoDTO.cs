using System.Text.Json.Serialization;

namespace Auth_API_1.DTOs
{
    public class VeiculoDTO
    {
        public string Nome { get; set; } = default!;
        public string? Descricao { get; set; }
        public string Marca { get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public int Ano { get; set; } = default!;
    }
}
