using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour
{
    public static string LevelName; // Глобальная переменная для хранения имени уровня
    private float savedTimeScale; // Переменная для сохранения состояния времени

    void Start()
    {
        // При старте сохраняем имя текущей сцены в LevelName
        LevelName = SceneManager.GetActiveScene().name;
    }

    public void OnPauseButtonPressed()
    {
        // Сохраняем текущее состояние времени и ставим на паузу
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0;

        // Загружаем сцену PauseScreen
        SceneManager.LoadScene("PauseScreen", LoadSceneMode.Additive);
    }
}
