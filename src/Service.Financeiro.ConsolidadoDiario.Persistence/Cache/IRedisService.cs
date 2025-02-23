namespace Service.Financeiro.ConsolidadoDiario.Persistence.Cache
{
    public interface IRedisService
    {
        Task<bool> SetDataAsync<T>(string key, T model, TimeSpan time);
        Task<T> GetDataAsync<T>(string key);
        Task DeleteDataAsync(string key);
    }
}