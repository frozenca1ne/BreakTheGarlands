using UnityEngine;

namespace PickUps
{
    public class AddLifePickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}
