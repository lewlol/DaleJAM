using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject otherui;
    public GameObject shoppanel;
    public GameObject ShopPrompt;

    private void Start()
    {
        shoppanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        openshop();


        
    }


    void openshop()
    {
        if (ShopPrompt.activeSelf && Input.GetKeyDown(KeyCode.B))
        {
            shoppanel.SetActive(true);
            otherui.SetActive(false);

        }
    }
}