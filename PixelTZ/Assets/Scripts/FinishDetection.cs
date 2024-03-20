using UnityEngine;
using UnityEngine.UI;

public class FinishDetection : MonoBehaviour
{
    public Button[] buttons;

    private void OnTriggerEnter(Collider other)
    {
        foreach (Button button in buttons)
        {
            if (button.CompareTag("Win"))
            {
                // �������� ������ � ����� "Win"
                button.gameObject.SetActive(true);
            }
            else
            {
                // ��������� ��� ��������� ������
                button.gameObject.SetActive(false);
            }
        }

        // ������������� ����
        Time.timeScale = 0f;
    }
}
