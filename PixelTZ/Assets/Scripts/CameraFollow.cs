using UnityEngine;

public class CarCameraFollow : MonoBehaviour
{
    void Update()
    {
        // �������� ��������� ������ �� PlayerPrefs
        int selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0);
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car"); // ������������, ��� � ����� ���������� ��� "Car"
        if (selectedCarIndex >= 0 && selectedCarIndex < cars.Length)
        {
            // �������� ��������� ��������� ������
            Transform target = cars[selectedCarIndex].transform;

            // ������������� ������� ������ ��� ������� ���� � ������ ��������
            transform.position = target.position - target.forward * 8f + Vector3.up * 2f;

            // ���������� ������ �� ����
            transform.LookAt(target.position + Vector3.up * 2f);
        }
        else
        {
            Debug.LogWarning("Selected car index is out of range!");
        }
    }
}
