using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
    public void BackToLevel()
    {
        // Возобновляем масштаб времени для продолжения игры
        Time.timeScale = 1;

        // Закрываем сцену паузы
        SceneManager.UnloadSceneAsync("PauseScreen");
    }

    public void RestartLevel()
    {
        // Проверяем, задано ли имя уровня
        if (!string.IsNullOrEmpty(PauseButtonScript.LevelName))
        {
            // Перезапускаем текущий уровень и восстанавливаем масштаб времени
            SceneManager.LoadScene(PauseButtonScript.LevelName);
            Time.timeScale = 1;
        }
        else
        {
            Debug.LogWarning("Имя уровня не задано в LevelName!");
        }
    }

    public void GoToLevelSelection()
    {
        // Переход на сцену выбора уровня
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelection");
    }
}
