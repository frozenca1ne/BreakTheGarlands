using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LifesController : MonoBehaviour
    {
        [SerializeField] private Image[] lifes;

        private void OnEnable()
        {
            LevelManager.OnLifeRemove += RemoveLife;
        }

        private void OnDisable()
        {
            LevelManager.OnLifeRemove -= RemoveLife;
        }

        private void RemoveLife(int index)
        {
            lifes[index].gameObject.SetActive(false);
        }
        
        public void AddLife(int index)
        {
            
            lifes[index].gameObject.SetActive(true);
        }
    }
}
