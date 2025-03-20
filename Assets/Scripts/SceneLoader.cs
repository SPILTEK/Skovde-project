using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("MadsTest");
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("MadsTest");
    }
}