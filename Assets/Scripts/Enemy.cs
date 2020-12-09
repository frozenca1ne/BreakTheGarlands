using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int pointsPerEnemy = 1;

    public int PointsPerEnemy => pointsPerEnemy;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
