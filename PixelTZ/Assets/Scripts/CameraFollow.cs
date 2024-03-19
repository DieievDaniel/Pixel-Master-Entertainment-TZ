using UnityEngine;

public class CarCameraFollow : MonoBehaviour
{
    void Update()
    {
        // Получаем выбранную машину из PlayerPrefs
        int selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0);
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car"); // Предполагаем, что у машин установлен тег "Car"
        if (selectedCarIndex >= 0 && selectedCarIndex < cars.Length)
        {
            // Получаем трансформ выбранной машины
            Transform target = cars[selectedCarIndex].transform;

            // Устанавливаем позицию камеры как позиция цели с учетом смещения
            transform.position = target.position - target.forward * 8f + Vector3.up * 2f;

            // Направляем камеру на цель
            transform.LookAt(target.position + Vector3.up * 2f);
        }
        else
        {
            Debug.LogWarning("Selected car index is out of range!");
        }
    }
}
