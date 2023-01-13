using Auth_API_1.Models;
using Auth_API_1.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth_API_1.Repositorios.Entity
{
    public class VeiculoRepositorioEntity : IServico<Veiculo>
    {
        private ContextoEntity contexto;
        public VeiculoRepositorioEntity()
        {
            contexto = new ContextoEntity();
        }

        public async Task<List<Veiculo>> TodosAsync()
        {
            return await contexto.Veiculos.ToListAsync();
        }

        public async Task IncluirAsync(Veiculo obj)
        {
            contexto.Veiculos.Add(obj);
            await contexto.SaveChangesAsync();
        }

        public async Task<Veiculo> AtualizarAsync(Veiculo obj)
        {
            contexto.Entry(obj).State = EntityState.Modified;
            await contexto.SaveChangesAsync();

            return obj;
        }

        public async Task ApagarAsync(Veiculo obj)
        {
            var cliente = await contexto.Veiculos.FindAsync(obj.Id);
            if (cliente is null) throw new Exception("Veículo não encontrado");
            contexto.Veiculos.Remove(cliente);
            await contexto.SaveChangesAsync();
        }
    }
}
