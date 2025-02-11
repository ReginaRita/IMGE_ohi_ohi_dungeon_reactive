using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneLoader", order = 1)]
public class SceneLoader : ScriptableObject
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void LoadLevel()
    {
        GameData.LastScore = 0;
        SceneManager.LoadScene("Level");
    }

    public static void LoadGameOver()
    {
        GameData.Instance.SaveScoreForGameOver();
        SceneManager.LoadScene("GameOver");
    }

    public static void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }
}