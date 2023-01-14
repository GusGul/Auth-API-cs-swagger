using Auth_API_1.DTOs;
using Auth_API_1.Filtros;
using Auth_API_1.Models;
using Auth_API_1.Repositorios.Interfaces;
using Auth_API_1.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API_1.Controllers
{
    [Route("administradores")]
    [Logado]
    public class AdministradorController : ControllerBase
    {
        private IServico<Administrador> _servico;
        public AdministradorController(IServico<Administrador> servico)
        {
            _servico = servico;
        }

        [HttpGet("")]
        [Permissao(Nivel = "adm,editor")]
        public async Task<IActionResult> Index()
        {
            var administradores = await _servico.TodosAsync();
            return StatusCode(200, administradores);
        }

        [HttpGet("{id}")]
        [Permissao(Nivel = "adm,editor")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var administrador = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, administrador);
        }

        [HttpPost("")]
        [Permissao(Nivel = "adm,editor")]
        public async Task<IActionResult> Create([FromBody] Administrador adm)
        {
            var administrador = BuilderServico<Administrador>.Builder(adm);
            await _servico.IncluirAsync(administrador);
            return StatusCode(201, administrador);
        }

        [HttpPut("{id}")]
        [Permissao(Nivel = "adm")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Administrador administrador)
        {
            if (id != administrador.Id)
            {
                return StatusCode(400, new
                {
                    Mensagem = "O Id do administrador precisa bater com o id da URL"
                });
            }

            var administradorDb = await _servico.AtualizarAsync(administrador);

            return StatusCode(200, administradorDb);
        }

        [HttpDelete("{id}")]
        [Permissao(Nivel = "adm")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var administradorDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (administradorDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "O administrador informado não existe"
                });
            }

            await _servico.ApagarAsync(administradorDb);

            return StatusCode(204);
        }
    }
}