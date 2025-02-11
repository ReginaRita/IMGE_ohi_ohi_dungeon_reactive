using System;
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
    }

    private void OnEnable()
    {
        if (_scoreText == null)
        {
            Debug.LogError("scoreText is not assinged");
        }

        GameData.Instance.ScoreUpdated += ScoreChanged; // subscribe ScoreUpdated
    }

    public void OnDisable()
    {
        GameData.Instance.ScoreUpdated -= ScoreChanged; //  unsubscribe ScoreUpdated
    }

    // Methode, die den Text bei einer Score-Änderung anpasst
    private void ScoreChanged(object sender, ScoreUpdatedEventArgs e)
    {
        SetText(e.CurrentScore.ToString());
    }
    
    // Setze den Text auf den aktuellen Punktestand
    private void SetText(string score)
    {
        _scoreText.text = score;
    }
}