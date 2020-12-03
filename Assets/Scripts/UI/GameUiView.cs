using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUiView : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Image[] lives;
        [SerializeField] private Button settingButton;
        [SerializeField] private CanvasGroup settingsPanel;
        [SerializeField] private CanvasGroup loseGamePanel;

        private void OnEnable()
        {
            settingButton.onClick.AddListener(OpenSettingsPanel);
        }

        private void OpenSettingsPanel()
        {
            settingsPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
