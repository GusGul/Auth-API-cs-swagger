using Auth_API_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth_API_1.Repositorios.Entity
{
    public class ContextoEntity : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_CDF");
            if (conexao is null) conexao = "Server=localhost;Database=empresa;Uid=root;Pwd=179179;";
            optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
        }

        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;
    }
}
