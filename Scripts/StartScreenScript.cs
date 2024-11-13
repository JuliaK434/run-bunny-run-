using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        if (volumeSlider != null)
        {
            // Устанавливаем начальное значение громкости
            AudioListener.volume = volumeSlider.value;
            // Добавляем обработчик события изменения значения ползунка
            volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
        }
        else
        {
            Debug.LogWarning("VolumeSlider не назначен в Inspector.");
        }
    }

    // Метод для перехода к экрану выбора уровня
    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");  // Переход к сцене выбора уровней
    }

    // Метод для установки громкости
    public void SetVolume()
    {
        if (volumeSlider != null)
        {
            AudioListener.volume = volumeSlider.value;
        }
        else
        {
            Debug.LogWarning("VolumeSlider не назначен в Inspector.");
        }
    }
}
