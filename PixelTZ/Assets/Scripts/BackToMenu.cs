using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public void BackToTheMenu()
    {
        SceneManager.LoadScene("Scene1");
    }
}
