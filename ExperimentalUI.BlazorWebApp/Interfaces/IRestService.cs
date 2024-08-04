using ExperimentalUI.BlazorWebApp.Models.Options;

namespace ExperimentalUI.BlazorWebApp.Interfaces;

public interface IRestService<T, TOptions>
    where T : class
    where TOptions : RestOptions
{
    Task<T> CreateAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(Guid id);
}