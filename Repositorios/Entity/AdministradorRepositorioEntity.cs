using Auth_API_1.Models;
using Auth_API_1.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth_API_1.Repositorios.Entity
{
    public class AdministradorRepositorioEntity : IServicoADM<Administrador>
    {
        private ContextoEntity contexto;
        public AdministradorRepositorioEntity()
        {
            contexto = new ContextoEntity();
        }

        private string? conexao = null;

        public async Task<Administrador?> Login(string login, string senha)
        {
            return await contexto.Administradores.Where(a => a.Login == login && a.Senha == senha).FirstOrDefaultAsync();
        }

        public async Task<List<Administrador>> TodosAsync()
        {
            return await contexto.Administradores.ToListAsync();
        }

        public async Task IncluirAsync(Administrador obj)
        {
            contexto.Administradores.Add(obj);
            await contexto.SaveChangesAsync();
        }

        public async Task<Administrador> AtualizarAsync(Administrador obj)
        {
            contexto.Entry(obj).State = EntityState.Modified;
            await contexto.SaveChangesAsync();

            return obj;
        }

        public async Task ApagarAsync(Administrador obj)
        {
            var administrador = await contexto.Administradores.FindAsync(obj.Id);
            if (administrador is null) throw new Exception("Administrador não encontrado");
            contexto.Administradores.Remove(administrador);
            await contexto.SaveChangesAsync();
        }
    }
}
