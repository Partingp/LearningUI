using ExperimentalUI.BlazorWebApp.Models;

namespace ExperimentalUI.BlazorWebApp.DTOs;

public class UpdateAnimalDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Thumbnail { get; set; }

    public bool IsDomestic { get; set; }

    public string[] Locations { get; set; }

    public float Weight { get; set; }

    public float Height { get; set; }

    public Scores Scores { get; set; }
}