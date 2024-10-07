namespace ExperimentalUI.BlazorWebApp.DTOs;

public class CreateAnimalDTO
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Thumbnail { get; set; }

    public bool IsDomestic { get; set; }

    public string[] Locations { get; set; }

    public float Weight { get; set; }

    public float Height { get; set; }

    public Scores Scores { get; set; }
}