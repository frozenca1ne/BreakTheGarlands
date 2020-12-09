using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static event Action OnLifeAdded;
    public static event Action<float,float > OnGravityChanged;
    
    [SerializeField] private float minMovementX = -1.8f;
    [SerializeField] private float maxMovementX = 1.8f;

    [SerializeField] private float gravityScaleDelay = 15f;
    [SerializeField] private float fastGravityCount = -13f;
    [SerializeField] private float slowGravityCount = -4f;

    [SerializeField] private LevelManager levelManager;
    
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        var mousePosition = Input.mousePosition;
        if (Camera.main is null) return;
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var mouseX = mouseWorldPosition.x;
        var clampMouseX = Mathf.Clamp(mouseX, minMovementX, maxMovementX);
        var mouseY = transform.position.y;
        transform.position = new Vector3(clampMouseX, mouseY, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LifeAdd"))
        {
            OnLifeAdded?.Invoke();
        }

        if (other.gameObject.CompareTag("FastGravity"))
        {
            OnGravityChanged?.Invoke(gravityScaleDelay,fastGravityCount);
        }

        if (other.gameObject.CompareTag("SlowGravity"))
        {
            OnGravityChanged?.Invoke(gravityScaleDelay,slowGravityCount);
        }

        if (!other.gameObject.CompareTag("Enemy")) return;
        var points = other.gameObject.GetComponent<Enemy>().PointsPerEnemy;
        levelManager.AddPointToScore(points);
    }
}
