using Auth_API_1.DTOs;
using Auth_API_1.Models;
using Auth_API_1.ModelViews;
using Auth_API_1.Repositorios.Interfaces;
using Auth_API_1.Servicos.Autenticacao;
using Auth_API_1.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API_1.Controllers
{
    public class LoginController : ControllerBase
    {
        private IServicoADM<Administrador> _servico;
        public LoginController(IServicoADM<Administrador> servico)
        {
            _servico = servico;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] AdministradorDTO administradorDTO)
        {
            if (string.IsNullOrEmpty(administradorDTO.Login) || string.IsNullOrEmpty(administradorDTO.Senha))
                return StatusCode(400, new
                {
                    Mensagem = "Preencha o email e a senha"
                });

            var administrador = await _servico.Login(administradorDTO.Login, administradorDTO.Senha);
            if (administrador is null)
                return StatusCode(404, new
                {
                    Mensagem = "Usuario ou senha não encontrado em nossa base de dados"
                });

            var administradorLogado = BuilderServico<AdministradorLogado>.Builder(administrador);
            administradorLogado.Token = TokenJWT.Builder(administradorLogado);

            return StatusCode(200, administradorLogado);
        }
    }
}
