using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessScreenScript : MonoBehaviour
{
    // Метод для перехода на следующий уровень
    public void NextLevel()
    {
        string nextSceneName;

        // Определяем следующий уровень на основе текущего LevelName
        switch (PauseButtonScript.LevelName)
        {
            case "Level1":
                nextSceneName = "Level2";
                break;
            case "Level2":
                nextSceneName = "Level3";
                break;
            case "Level3":
                nextSceneName = "Level4";
                break;
            case "Level4":
                nextSceneName = "Level5";
                break;
            case "Level5":
                nextSceneName = "StartScreen"; // Возвращаем игрока на стартовый экран после последнего уровня
                break;
            default:
                Debug.LogWarning("Unknown level name. Returning to StartScreen.");
                nextSceneName = "StartScreen";
                break;
        }

        // Загружаем следующую сцену
        SceneManager.LoadScene(nextSceneName);
    }

    // Метод для перезапуска текущего уровня
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
