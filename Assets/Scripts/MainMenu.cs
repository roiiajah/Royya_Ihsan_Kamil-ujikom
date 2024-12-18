using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
              
    }

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Exit(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
}
