using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreLabel : MonoBehaviour
{
    // reference to the relevant Text component
    private Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<Text>();
    }

    private void Start()
    {
        _scoreText.text = GameData.LastScore.ToString();

        GameData.Instance.Score
            .Select(score => score.ToString())
            .Subscribe(scoreText => _scoreText.text = scoreText)
            .AddTo(this);
    }
}