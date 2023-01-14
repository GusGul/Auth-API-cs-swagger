using Auth_API_1.DTOs;
using Auth_API_1.ModelViews;
using Jose;

namespace Auth_API_1.Servicos.Autenticacao
{
    public class TokenJWT
    {
        public static string Builder(AdministradorLogado AdministradorLogado)
        {
            var key = "SEGREDO_do_CoDigoDO-Futuro";

            var payload = new AdministradorJwtDTO
            {
                Id = AdministradorLogado.Id,
                Login = AdministradorLogado.Login,
                Regra = AdministradorLogado.Regra,
                Expiracao = DateTime.Now.AddDays(1)
            };

            string token = Jose.JWT.Encode(payload, key, JwsAlgorithm.none);

            return token;
        }

    }
}
