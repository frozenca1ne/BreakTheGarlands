using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoseGameView : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button restartButton;

    private void OnEnable()
    {
        LevelManager.OnGameLose += GetFinalScore;
        
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        restartButton.onClick.AddListener(ResetGame);
    }

    private void OnDisable()
    {
        LevelManager.OnGameLose -= GetFinalScore;
    }

    private void GetFinalScore(int score)
    {
        finalScoreText.text = $"SCORE : {score}";
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ResetGame()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
