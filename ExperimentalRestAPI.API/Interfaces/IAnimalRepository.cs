using ExperimentalRestAPI.API.Models;

namespace ExperimentalRestAPI.API.Interfaces;

public interface IAnimalRepository
{
    Task<IEnumerable<Animal>> GetAllAsync();
    Task<Animal> GetByIdAsync(Guid id);
    Task AddAsync(Animal animal);
    Task UpdateAsync(Guid id, Animal animal);
    Task DeleteAsync(Guid id);
}