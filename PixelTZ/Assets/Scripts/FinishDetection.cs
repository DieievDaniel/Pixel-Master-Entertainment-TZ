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
                // Включаем кнопку с тегом "Win"
                button.gameObject.SetActive(true);
            }
            else
            {
                // Отключаем все остальные кнопки
                button.gameObject.SetActive(false);
            }
        }

        // Останавливаем игру
        Time.timeScale = 0f;
    }
}
