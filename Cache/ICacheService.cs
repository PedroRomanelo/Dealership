namespace Dealership.Cache;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key); //lê

    Task SetAsync<T>(string key, T value, TimeSpan? expiry = null); //grava

    Task RemoveAsync(string key); 
}
