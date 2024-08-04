using AutoMapper;
using ExperimentalRestAPI.API.DTOs;
using ExperimentalRestAPI.API.Interfaces;
using ExperimentalRestAPI.API.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExperimentalRestAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateAnimalDTO> _createValidator;
    private readonly IValidator<UpdateAnimalDTO> _updateValidator;

    public AnimalController(IAnimalRepository animalRepository, IMapper mapper,
        IValidator<CreateAnimalDTO> createAnimalDtoValidator, IValidator<UpdateAnimalDTO> updateAnimalDtoValidator)
    {
        _animalRepository = animalRepository;
        _mapper = mapper;
        _createValidator = createAnimalDtoValidator;
        _updateValidator = updateAnimalDtoValidator;
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
        var validationResult = await _createValidator.ValidateAsync(animalDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.ToDictionary());
        }

        var animal = _mapper.Map<Animal>(animalDto);
        await _animalRepository.AddAsync(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnimalAsync([FromRoute] Guid id, UpdateAnimalDTO animalDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(animalDto);

        if (!validationResult.IsValid || id != animalDto.Id)
        {
            return BadRequest(validationResult.ToDictionary());
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