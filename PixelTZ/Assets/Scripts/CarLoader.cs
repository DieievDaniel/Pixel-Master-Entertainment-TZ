using UnityEngine;
using UnityEngine.SceneManagement;

public class CarLoader : MonoBehaviour
{
    public GameObject[] cars; // Список всех машин в сцене 2
    public Camera[] cameras; // Список всех камер в сцене 2

    void Start()
    {
        int selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0); // Получаем индекс выбранной машины
        if (selectedCarIndex < 0 || selectedCarIndex >= cars.Length)
        {
            return;
        }

        // Активируем выбранную машину
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == selectedCarIndex);
        }

        // Отключаем все камеры, кроме нужной
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == selectedCarIndex);
        }
    }
}
