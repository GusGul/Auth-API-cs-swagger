namespace Auth_API_1.Repositorios.Interfaces
{
    public interface IServicoADM<T> : IServico<T>
    {
        Task<T?> Login(string login, string senha);
    }
}
