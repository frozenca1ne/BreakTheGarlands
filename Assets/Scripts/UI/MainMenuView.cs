using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Text bestScoreText;
        [SerializeField] private Button startButton;

        private void OnEnable()
        {
            startButton.onClick.AddListener(LoadGameScene);
            SetBestScore();
        }

        private void SetBestScore()
        {
            var bestScore = PlayerPrefs.GetInt("BestScore", 0);
            bestScoreText.text = $"BEST \nSCORE :{bestScore}";
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    
    }
}
