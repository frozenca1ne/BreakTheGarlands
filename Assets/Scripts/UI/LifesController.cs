using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LifesController : MonoBehaviour,ILifeAdd
    {
        [SerializeField] private Image[] lifes;

        private void RemoveLife(int index)
        {
            lifes[index].gameObject.SetActive(false);
        }

        private void ResetLifes()
        {
            foreach (var life in lifes )
            {
                life.gameObject.SetActive(true);
            }
        }
        public void AddLife(int index)
        {
            lifes[index].gameObject.SetActive(true);
        }
    }
}
