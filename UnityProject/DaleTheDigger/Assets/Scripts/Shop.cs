using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject otherui;
    public GameObject shoppanel;
    public GameObject ShopPrompt;

    public int staminalevel;
    public int fortunelevel;
    public int pickaxelevel;

    public TextMeshProUGUI staminaleveltext;
    public TextMeshProUGUI fortuneleveltext;
    public TextMeshProUGUI pickaxeleveltext;



    private void Start()
    {
        shoppanel.SetActive(false);
        staminalevel = 1;
        fortunelevel = 1;
        pickaxelevel = 1;
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
            shoppanel.SetActive(false);
            otherui.SetActive(true);
        }
    }

    private void Update()
    {
        openshop();
        shopstats();

        
    }


    void openshop()
    {
        if (ShopPrompt.activeSelf && Input.GetKeyDown(KeyCode.B))
        {
            shoppanel.SetActive(true);
            otherui.SetActive(false);

        }
    }

    void shopstats()
    {
        staminaleveltext.text = "Level: " + staminalevel;
        pickaxeleveltext.text = "Level: " + pickaxelevel;
        fortuneleveltext.text = "Level: " + fortunelevel;
    }

    public void staminabutton()
    {
        staminalevel++;
        PlayerMovement.stamina += 5;
    }

    public void fortunebutton()
    {
        fortunelevel++;
        PlayerMovement.fortune += 5;
    }

    public void breakingbutton()
    {
        pickaxelevel++;
        PlayerMovement.breakingpower += 1;
    }


}