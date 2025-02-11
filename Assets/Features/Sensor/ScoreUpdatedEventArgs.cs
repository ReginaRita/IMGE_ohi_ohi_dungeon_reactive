using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdatedEventArgs : EventArgs
{
    public int CurrentScore { get; }

    public ScoreUpdatedEventArgs(int currentScore)
    {
        CurrentScore = currentScore;
    }
}