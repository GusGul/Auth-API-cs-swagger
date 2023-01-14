using Auth_API_1.DTOs;
using Auth_API_1.Filtros;
using Auth_API_1.Models;
using Auth_API_1.Repositorios.Interfaces;
using Auth_API_1.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API_1.Controllers
{
    [Route("veiculos")]
    [Logado]
    public class VeiculosController : ControllerBase
    {
        private IServico<Veiculo> _servico;
        public VeiculosController(IServico<Veiculo> servico)
        {
            _servico = servico;
        }

        [HttpGet("")]
        [Permissao(Nivel = "adm,editor")]
        public async Task<IActionResult> Index()
        {
            var veiculos = await _servico.TodosAsync();
            return StatusCode(200, veiculos);
        }

        [HttpGet("{id}")]
        [Permissao(Nivel = "adm,editor")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var veiculo = (await _servico.TodosAsync()).Find(c => c.Id == id);

            return StatusCode(200, veiculo);
        }

        [HttpPost("")]
        [Permissao(Nivel = "adm,editor")]
        public async Task<IActionResult> Create([FromBody] VeiculoDTO veiculoDTO)
        {
            var veiculo = BuilderServico<Veiculo>.Builder(veiculoDTO);
            await _servico.IncluirAsync(veiculo);
            return StatusCode(201, veiculo);
        }

        [HttpPut("{id}")]
        [Permissao(Nivel = "adm")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return StatusCode(400, new
                {
                    Mensagem = "O Id do cliente precisa bater com o id da URL"
                });
            }

            var veiculoDb = await _servico.AtualizarAsync(veiculo);

            return StatusCode(200, veiculoDb);
        }

        [HttpDelete("{id}")]
        [Permissao(Nivel = "adm")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var veiculoDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
            if (veiculoDb is null)
            {
                return StatusCode(404, new
                {
                    Mensagem = "O cliente informado não existe"
                });
            }

            await _servico.ApagarAsync(veiculoDb);

            return StatusCode(204);
        }
    }
}