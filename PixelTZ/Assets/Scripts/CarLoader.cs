using UnityEngine;
using UnityEngine.SceneManagement;

public class CarLoader : MonoBehaviour
{
    public GameObject[] cars; 
    public Camera[] cameras; 

    void Start()
    {
        int selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0);
        if (selectedCarIndex < 0 || selectedCarIndex >= cars.Length)
        {
            return;
        }
   
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == selectedCarIndex);
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == selectedCarIndex);
        }
    }
}
