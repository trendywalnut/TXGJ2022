using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPlayScene : MonoBehaviour
{
    
    public void ReloadScene()
    {
        SceneManager.LoadScene("Play Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
