using UnityEngine;

namespace PickUps
{
    public class AddLifePickUp : MonoBehaviour
    {

        [SerializeField] private int lifePerPickUp = 1;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                
            }
            Destroy(gameObject);
        }

        
    }
}
