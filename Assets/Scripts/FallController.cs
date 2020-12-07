using System;
using UnityEngine;

public class FallController : MonoBehaviour
{
    public static event Action OnEnemyFall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag($"Enemy"))
        {
            OnEnemyFall?.Invoke();
        }
        
    }
}
