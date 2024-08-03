using ExperimentalRestAPI.API.Interfaces;
using ExperimentalRestAPI.API.Models;
using MongoDB.Driver;

namespace ExperimentalRestAPI.API.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IMongoCollection<Animal> _animals;

    public AnimalRepository(IMongoDatabase database)
    {
        _animals = database.GetCollection<Animal>("Animal");
    }

    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        return await _animals.Find(animal => true).ToListAsync();
    }

    public async Task<Animal> GetByIdAsync(Guid id)
    {
        return await _animals.Find<Animal>(animal => animal.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Animal animal)
    {
        await _animals.InsertOneAsync(animal);
    }

    public async Task UpdateAsync(Guid id, Animal animal)
    {
        await _animals.ReplaceOneAsync(a => a.Id == id, animal);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _animals.DeleteOneAsync(animal => animal.Id == id);
    }
}
