﻿namespace Auth_API_1.Repositorios.Interfaces
{
    public interface IServico<T>
    {
        Task<List<T>> TodosAsync();
        Task IncluirAsync(T obj);
        Task<T> AtualizarAsync(T obj);
        Task ApagarAsync(T obj);
    }
}
