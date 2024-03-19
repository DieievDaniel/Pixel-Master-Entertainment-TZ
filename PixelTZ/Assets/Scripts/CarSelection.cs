using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;
    private int selectedCarIndex = 0;

    public void SelectNextCar()
    {
        cars[selectedCarIndex].SetActive(false);

        selectedCarIndex = (selectedCarIndex + 1) % cars.Length;

        cars[selectedCarIndex].SetActive(true);
    }

    public void SelectPreviousCar()
    {
        cars[selectedCarIndex].SetActive(false);

        selectedCarIndex = (selectedCarIndex - 1 + cars.Length) % cars.Length;

        cars[selectedCarIndex].SetActive(true);
    }

    public void Play()
    {
        PlayerPrefs.SetInt("SelectedCarIndex", selectedCarIndex);
        SceneManager.LoadScene("Scene2");
    }
}
