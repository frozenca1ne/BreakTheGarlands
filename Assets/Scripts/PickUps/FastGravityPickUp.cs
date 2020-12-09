using UnityEngine;

namespace PickUps
{
    public class FastGravityPickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
           
            Destroy(gameObject);
        }
    }
}
