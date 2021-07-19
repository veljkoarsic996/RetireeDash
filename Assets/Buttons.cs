using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public void Play() {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameLevel");
        SceneManager.UnloadScene("MainMenu");
    }
    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.UnloadScene("GameLevel");
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
