using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUiView : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Button settingButton;
        [SerializeField] private CanvasGroup settingsPanel;
        [SerializeField] private CanvasGroup loseGamePanel;

        private void OnEnable()
        {
            LevelManager.OnGameLose += OpenLosePanel;
            LevelManager.OnPointsAdd += SetScore;
            settingButton.onClick.AddListener(OpenSettingsPanel);
        }
        private void OnDisable()
        {
            LevelManager.OnGameLose -= OpenLosePanel;
            LevelManager.OnPointsAdd -= SetScore;
        }

        private void OpenSettingsPanel()
        {
            settingsPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void OpenLosePanel(int i)
        {
            loseGamePanel.gameObject.SetActive(true);
        }

        private void SetScore(int score)
        {
            scoreText.text = $"SCORE : {score}";
        }
    }
}
