using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LifesController : MonoBehaviour,ILifeAdd
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
            Debug.Log("h");
            lifes[index].gameObject.SetActive(false);
        }
        
        public void AddLife(int index)
        {
            
            lifes[index].gameObject.SetActive(true);
        }
    }
}
