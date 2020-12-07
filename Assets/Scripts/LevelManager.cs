using System;
using System.Collections;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static event Action<int> OnLifeRemove;
    public static event Action<int> OnGameLose;
    
    
    [Header("Lifes")]
    [SerializeField]
    private int lifesCount = 3;

    private int _pointsInCurrentGame = 0;
    private const float StandartGravity = -9.81f;

    private void OnEnable()
    {
        FallController.OnEnemyFall += ChangeLifesCount;
    }

    private void OnDisable()
    {
        FallController.OnEnemyFall -= ChangeLifesCount;
    }

    private void ChangeLifesCount()
    {
        lifesCount -= 1;
        OnLifeRemove?.Invoke(lifesCount);
        if (lifesCount > 0) return;
        OnGameLose?.Invoke(_pointsInCurrentGame);
        ModifyBestScore(_pointsInCurrentGame);
        Time.timeScale = 0;
    }
    private void ModifyBestScore(int score)
    {
        var bestScore = PlayerPrefs.GetInt("BestScore");
        if (bestScore >= score) return;
        PlayerPrefs.SetInt("BestScore", score);
    }
    private void AddPointToScore(int points)
    {
        _pointsInCurrentGame += points;
    }
    
    public void AddLife()
    {
        if (lifesCount >= 3) return;
        lifesCount++;
    }
    public void GravityChange(float delay,float value)
    {
        StartCoroutine(ChangeGravity(delay, value));
    }
   
   
    private IEnumerator ChangeGravity(float delay, float value)
    {
        Physics2D.gravity = new Vector2(0, value);
        yield return new WaitForSeconds(delay);
        Physics2D.gravity = new Vector2(0, StandartGravity);
    }
}
