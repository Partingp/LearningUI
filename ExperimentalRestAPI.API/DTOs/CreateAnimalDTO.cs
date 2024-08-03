namespace ExperimentalRestAPI.API.DTOs;

public class CreateAnimalDTO
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Thumbnail { get; set; }

    public bool IsDomestic { get; set; }
}