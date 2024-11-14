using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance; // Переменная для отслеживания единственного экземпляра

    public AudioClip backgroundMusic; // Ваш аудиофайл
    private AudioSource audioSource; // Источник звука

    void Awake()
    {
        // Проверяем, есть ли уже объект с фоновым звуком
        if (instance != null && instance != this)
        {
            // Если экземпляр уже существует, уничтожаем этот объект
            Destroy(gameObject);
        }
        else
        {
            // Если экземпляр еще не существует, сохраняем текущий объект как единственный
            instance = this;
            DontDestroyOnLoad(gameObject); // Этот объект не будет уничтожен при смене сцены
        }
    }

    void Start()
    {
        // Получаем компонент AudioSource на этом объекте
        audioSource = GetComponent<AudioSource>();

        // Если AudioSource не прикреплен, добавляем его
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Устанавливаем фоновую музыку и начинаем воспроизведение
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Музыка будет повторяться
        audioSource.Play();
    }
}