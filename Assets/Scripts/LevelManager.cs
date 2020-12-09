using System;
using System.Collections;
using UI;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static event Action<int> OnLifeRemove;
    public static event Action<int> OnGameLose;
    public static event Action<int> OnPointsAdd;
    
    
    [Header("Lifes")]
    [SerializeField]
    private int lifesCount = 3;

    [SerializeField] private LifesController lifesController;

    private int _pointsInCurrentGame = 0;
    private const float StandartGravity = -9.81f;
    
    public void AddPointToScore(int points)
    {
        _pointsInCurrentGame += points;
        OnPointsAdd?.Invoke(_pointsInCurrentGame);
    }
    private void OnEnable()
    {
        FallController.OnEnemyFall += ChangeLifesCount;
        Platform.OnLifeAdded += AddLife;
        Platform.OnGravityChanged += GravityChange;
    }

    private void OnDisable()
    {
        FallController.OnEnemyFall -= ChangeLifesCount;
        Platform.OnLifeAdded -= AddLife;
        Platform.OnGravityChanged -= GravityChange;
    }
    private void AddLife()
    {
        if (lifesCount >= 3) return;
        lifesCount++;
        lifesController.AddLife(lifesCount - 1);
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
        var bestScore = PlayerPrefs.GetInt("BestScore",0);
        if (bestScore >= score) return;
        PlayerPrefs.SetInt("BestScore", score);
    }
    private void GravityChange(float delay,float value)
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
