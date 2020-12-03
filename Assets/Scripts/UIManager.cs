using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    
    [SerializeField] private CanvasGroup menuPanel;
    [SerializeField] private Image[] lifes;
    
    public void LifeUp(int index)
    {
        lifes[index - 1].gameObject.SetActive(true);
    }
    public void LifeDown(int index)
    {
        lifes[index].gameObject.SetActive(false);
    }
    public void ResetLifes()
    {
        var lifeCount = LevelManager.ReturnLifeCunt();
        for (var i = 0; i <= lifeCount -1; i++)
        {
            lifes[i].gameObject.SetActive(true);
        }
    }
   


}
