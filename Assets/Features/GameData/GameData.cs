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

    private int _score; // Can be modified by Score get() and set()
    public static int LastScore;
    
    
    // Event, das ausgelöst wird, wenn der Score aktualisiert wird
    public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated;
    
    // Implement a get/set construct for the score property to react to changes.
    public int Score
    {
        get => _score; 
        set
        {
            if (_score != value) // Nur wenn der Wert geändert wird
            {
                _score = value;
                // Event auslösen, wenn der Score geändert wird
                ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs(_score));
            }
        }
    }
    public ReactiveProperty<bool> abilityAvailable = new ReactiveProperty<bool>(false);
   
    [HideInInspector] public LevelTheme currentLevelTheme;
    private Random LevelThemeRandom = new Random();

    public void Awake()
    {
        currentLevelTheme = GetRandomLevelTheme();
    }

    public void IncreaseScore(int value)
    {
        Score += value; // löst das Event aus (set)
    }

    public void ResetScore()
    {
        Score = 0; // löst das Event aus (set)
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
        LastScore = Score;
    }
}