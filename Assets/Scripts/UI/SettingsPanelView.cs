using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SettingsPanelView : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Button mainSceneButton;
        [SerializeField] private Button returnButton;

        private void OnEnable()
        {
            volumeSlider.value = AudioPlayer.Instance.GetMusicVolume() * volumeSlider.maxValue;
            returnButton.onClick.AddListener(ReturnToGame);
            volumeSlider.onValueChanged.AddListener(SetMusicVolume);
            mainSceneButton.onClick.AddListener(LoadMainScene);
        }

        private void ReturnToGame()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        private void LoadMainScene()
        {
            SceneManager.LoadScene(0);
        }
        public void SetMusicVolume(float value)
        {
            AudioPlayer.Instance.MusicVolumeChange(value / volumeSlider.maxValue);
        }
    }
}
