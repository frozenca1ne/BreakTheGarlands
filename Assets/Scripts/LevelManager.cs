using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
   
   
    [Header("Score")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finalScoreText;
    
    [Header("Lifes")]
    [SerializeField]
    private static int _lifesCount = 3;

    private int _pointsInCurrentGame = 0;
    private int _bestScore = 0;
    private const float StandartGravity = -9.81f;

    public static int ReturnLifeCunt()
    {
        return  _lifesCount;
    }
    public void ChangeScore(int points)
    {
        _pointsInCurrentGame += points;

        ChangeScore();
    }
    public void ChangeLifesCount()
    {
        _lifesCount -= 1;
       // UIManager.Instance.LifeDown(_lifesCount);
        if (_lifesCount > 0) return;
        //UIManager.Instance.ActivateLoseGamePanel();
        GetFinalScore();
        ModifyBestScore(_pointsInCurrentGame);
        Time.timeScale = 0;

    }
    public void ResetScore()
    {
        _pointsInCurrentGame = 0;
        _lifesCount = 3;
        ChangeScore();
    }
    public void AddLife()
    {
        if (_lifesCount >= 3) return;
        _lifesCount++;
        //UIManager.Instance.ResetLifes();
    }
    public void GravityChange(float delay,float value)
    {
        StartCoroutine(ChangeGravity(delay, value));
    }
    private void ChangeScore()
    {
        scoreText.text = "SCORE : " + _pointsInCurrentGame;
    }
    private void GetFinalScore()
    {
        finalScoreText.text = "SCORE : " + _pointsInCurrentGame;
    }
    private void ModifyBestScore(int score)
    {
        if (_bestScore >= score) return;
        _bestScore = score;
        PlayerPrefs.SetInt("BestScore", score);

    }
    private IEnumerator ChangeGravity(float delay, float value)
    {
        Physics2D.gravity = new Vector2(0, value);
        yield return new WaitForSeconds(delay);
        Physics2D.gravity = new Vector2(0, StandartGravity);
    }
}
