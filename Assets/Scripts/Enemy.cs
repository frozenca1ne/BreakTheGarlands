using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int pointsPerEnemy = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fall"))
        {
           
        }
        else
        {
            
        }
        
        Destroy(gameObject);
    }
   
}
