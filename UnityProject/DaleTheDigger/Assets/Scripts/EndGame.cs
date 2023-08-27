using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject FadeOut;
    private void OnTriggerEnter2D(Collider2D other)
    {
        FadeOut.SetActive(true);
        SceneManager.LoadScene(2);
    }
}
