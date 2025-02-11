using System;
using UnityEngine;
using DyrdaDev.Singleton;
using R3;
using Random = System.Random;

public class GameData : SingletonMonoBehaviour<GameData>
{
    public enum LevelTheme
    {
        Demons,
        Undeads,
        Orcs
    }
    
    public static int LastScore;
    public ReactiveProperty<int> Score = new ReactiveProperty<int>(0);
    
    // Event, das ausgelöst wird, wenn der Score aktualisiert wird
    public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated;
    
    
    public ReactiveProperty<bool> abilityAvailable = new ReactiveProperty<bool>(false);
   
    [HideInInspector] public LevelTheme currentLevelTheme;
    private Random LevelThemeRandom = new Random();

    public void Awake()
    {
        currentLevelTheme = GetRandomLevelTheme();
    }

    public void IncreaseScore(int value)
    {
        Score.Value += value; // löst das Event aus (set)
    }

    public void ResetScore()
    {
        Score.Value = 0; // löst das Event aus (set)
    }

    public void SetAbilityAvailable(bool value)
    {
        abilityAvailable.Value = value;
    }


    private void GetNextLevelTheme()
    {
        var previousLevelTheme = currentLevelTheme;
        var newLevelTheme = currentLevelTheme;
        
        while (previousLevelTheme == newLevelTheme)
        {
            newLevelTheme = GetRandomLevelTheme();
        }

        currentLevelTheme = newLevelTheme;
    }


    public void Reset()
    {
        ResetScore();
        GetNextLevelTheme();
    }

    private LevelTheme GetRandomLevelTheme()
    {
        Array values = Enum.GetValues(typeof(LevelTheme));
        return (LevelTheme)values.GetValue(LevelThemeRandom.Next(values.Length));
    }

    public void SaveScoreForGameOver()
    {
        LastScore = Score.Value;
    }
}