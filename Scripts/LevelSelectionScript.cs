using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionScript : MonoBehaviour
{
    // Метод для загрузки сцены с выбранным уровнем
    public void LoadLevel(string levelName)
    {
        // Загружаем сцену по имени
        SceneManager.LoadScene(levelName);
    }

    // Метод для возвращения на начальный экран
    public void GoToStartScreen()
    {
        // Загружаем сцену начального экрана
        SceneManager.LoadScene("StartScreen");
    }
}