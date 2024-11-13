using UnityEngine;
using UnityEngine.SceneManagement;

public class UnsuccessScreenScript : MonoBehaviour
{
    // Метод для перезапуска уровня
    public void RestartLevel()
    {
        // Перезапускаем уровень, используя сохраненное значение LevelName
        SceneManager.LoadScene(PauseButtonScript.LevelName);
    }

    // Метод для перехода на экран выбора уровней
    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
