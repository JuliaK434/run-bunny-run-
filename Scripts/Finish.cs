using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    // �����, ������������� ��� ������������ � ������ ��������
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� ����� � ��������� "SuccessScreen"
        SceneManager.LoadScene("SuccessScreen");
    }
}

