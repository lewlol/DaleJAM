using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject otherui;
    public GameObject shoppanel;
    public GameObject ShopPrompt;

    public int staminalevel;
    public int staminacost = 50;

    public int fortunelevel;
    public int fortunecost = 50;

    public int pickaxelevel;
    public int pickaxecost = 500;




    public TextMeshProUGUI staminaleveltext;
    public TextMeshProUGUI fortuneleveltext;
    public TextMeshProUGUI pickaxeleveltext;
    public TextMeshProUGUI coins;





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
        coins.text = "Coins: " + PlayerMovement.coins;
    }

    public void staminabutton()
    {
        if (PlayerMovement.coins >= staminacost)
        {
            PlayerMovement.coins -= staminacost;
            staminalevel++;
            PlayerMovement.stamina += 5;
            staminacost += 20;
        }
        
    }

    public void fortunebutton()
    {
        if(PlayerMovement.coins >= fortunecost)
        {
            PlayerMovement.coins-= fortunecost;
            fortunelevel++;
            PlayerMovement.fortune += 5;
            fortunecost += 20;
        }

        
    }

    public void breakingbutton()
    {
        if(PlayerMovement.coins >= pickaxecost)
        {
            PlayerMovement.coins -= pickaxecost;
            pickaxelevel++;
            PlayerMovement.breakingpower += 1;
            pickaxecost += 500;
        }
       
    }


}