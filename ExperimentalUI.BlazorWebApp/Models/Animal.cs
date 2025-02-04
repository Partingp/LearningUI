﻿namespace ExperimentalUI.BlazorWebApp.Models;
public class Animal
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Thumbnail { get; set; }

    public bool IsDomestic { get; set; }

    public Scores Scores { get; set; }
}