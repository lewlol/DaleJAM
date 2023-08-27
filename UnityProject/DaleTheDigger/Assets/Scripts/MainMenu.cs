using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject info;

    public GameObject fadeIn;
    public GameObject fadeOut;
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
        StartCoroutine(ToGame());
    }
    IEnumerator ToGame()
    {
        EndSCene.cleartotals();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        fadeIn.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
        SceneManager.LoadScene(1);
    }
}