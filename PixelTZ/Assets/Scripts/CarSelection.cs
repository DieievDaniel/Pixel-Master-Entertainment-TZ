using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;
    private int selectedCarIndex = 0;

    public void SelectNextCar()
    {
        // Выключаем текущую машину
        cars[selectedCarIndex].SetActive(false);

        // Переход к следующей машине в круговом порядке
        selectedCarIndex = (selectedCarIndex + 1) % cars.Length;

        // Включаем выбранную машину
        cars[selectedCarIndex].SetActive(true);
    }

    public void SelectPreviousCar()
    {
        // Выключаем текущую машину
        cars[selectedCarIndex].SetActive(false);

        // Переход к предыдущей машине в круговом порядке
        selectedCarIndex = (selectedCarIndex - 1 + cars.Length) % cars.Length;

        // Включаем выбранную машину
        cars[selectedCarIndex].SetActive(true);
    }

    public void Play()
    {
        // Переход на следующую сцену и передача выбранной машины через PlayerPrefs
        PlayerPrefs.SetInt("SelectedCarIndex", selectedCarIndex);
        SceneManager.LoadScene("Scene2");
    }
}
