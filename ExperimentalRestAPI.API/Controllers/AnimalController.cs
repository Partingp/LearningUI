using AutoMapper;
using ExperimentalRestAPI.API.DTOs;
using ExperimentalRestAPI.API.Interfaces;
using ExperimentalRestAPI.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExperimentalRestAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IMapper _mapper;

    public AnimalController(IAnimalRepository animalRepository, IMapper mapper)
    {
        _animalRepository = animalRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CreateAnimalDTO>>> GetAnimals()
    {
        var animals = await _animalRepository.GetAllAsync();
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CreateAnimalDTO>> GetAnimal([FromRoute] Guid id)
    {
        var animal = await _animalRepository.GetByIdAsync(id);

        if (animal == null)
        {
            return NotFound();
        }

        return Ok(animal);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAnimalDTO>> CreateAnimalAsync(CreateAnimalDTO animalDto)
    {
        var animal = _mapper.Map<Animal>(animalDto);
        await _animalRepository.AddAsync(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnimalAsync([FromRoute] Guid id, UpdateAnimalDTO animalDto)
    {
        if (id != animalDto.Id)
        {
            return BadRequest();
        }

        var animal = await _animalRepository.GetByIdAsync(id);
        if (animal is null)
        {
            return NotFound();
        }

        var updatedAnimal = _mapper.Map<Animal>(animalDto);
        await _animalRepository.UpdateAsync(id, updatedAnimal);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimalAsync([FromRoute] Guid id)
    {
        var animal = await _animalRepository.GetByIdAsync(id);
        if (animal is null)
        {
            return NotFound();
        }

        await _animalRepository.DeleteAsync(id);
        return NoContent();
    }
}
