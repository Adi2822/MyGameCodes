using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    //public void LoadMenu()
    //{
        //SceneManager.LoadScene("MainMenu");
    //}

    public void QuitGame()
    {
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}
