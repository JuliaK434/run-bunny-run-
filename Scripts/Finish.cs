using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    // Метод, срабатывающий при столкновении с другим объектом
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Загружаем сцену с названием "SuccessScreen"
        SceneManager.LoadScene("SuccessScreen");
    }
}

