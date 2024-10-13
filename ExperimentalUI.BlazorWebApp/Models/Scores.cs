using ExperimentalUI.BlazorWebApp.Enums;

namespace ExperimentalUI.BlazorWebApp.Models;
public class Scores
{
    public int Cuteness { get; set; }

    public float Speed { get; set; }

    public int Mischief { get; set; }

    public int Lifespan { get; set; }

    public bool Pettable { get; set; }

    public Rarity Rarity { get; set; }

    //TODO - Calculate a better value using Speed, Pettable and Rarity
    public float Overall
    {
        get => ((Cuteness + Speed + Mischief
                + Lifespan) / 4);
    }
}