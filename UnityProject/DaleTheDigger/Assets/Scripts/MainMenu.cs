using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject infopanel;

    private void Start()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
    }

    public void play()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(true);
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }

}
