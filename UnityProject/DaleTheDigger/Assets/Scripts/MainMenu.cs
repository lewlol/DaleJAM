using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject info;

    private void Start()
    {
        mainMenu.SetActive(true);
        info.SetActive(false);
    }


    public void continuepog()
    {
        mainMenu.SetActive(false);
        info.SetActive(true);
    }

    public void Quitpog()
    {
        Application.Quit();
    }

    public void togamescene()
    {
        SceneManager.LoadScene(1);
    }
}