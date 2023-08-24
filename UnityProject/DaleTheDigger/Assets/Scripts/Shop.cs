using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject otherui;
    public GameObject shoppanel;

    public int staminalevel;
    public int staminacost = 50;

    public int fortunelevel;
    public int fortunecost = 50;

    public int pickaxelevel;
    public int pickaxecost = 500;

    //Artefact
    private int discountedPickaxeCost;
    private int discountedStaminaCost;
    private int discountedFortuneCost;



    public TextMeshProUGUI staminaleveltext;
    public TextMeshProUGUI fortuneleveltext;
    public TextMeshProUGUI pickaxeleveltext;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI staminacosttext;
    public TextMeshProUGUI fortunecosttext;
    public TextMeshProUGUI pickaxecosttext;

    public GameObject wg;
    public GameObject stamUI;
    bool inRadius;

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
            wg.GetComponent<Indicator>().EnableIndicator(true, 0f, "Press B to Open Shop");
            inRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shoppanel.SetActive(false);
            otherui.SetActive(true);
            wg.GetComponent<Indicator>().DisableIndicator();
            inRadius = false;
        }
    }

    private void Update()
    {
        openshop();
        shopstats();
    }

    void openshop()
    {
        if (inRadius && Input.GetKeyDown(KeyCode.B))
        {
            wg.GetComponent<Indicator>().DisableIndicator();
            shoppanel.SetActive(true);
            otherui.SetActive(false);
        }
    }

    void shopstats()
    {
         discountedPickaxeCost = (int)(pickaxecost * (1.0f - Artefacts.shopdiscount));
         discountedStaminaCost = (int)(staminacost * (1.0f - Artefacts.shopdiscount));
         discountedFortuneCost = (int)(fortunecost * (1.0f - Artefacts.shopdiscount));

        pickaxecosttext.text = discountedPickaxeCost + " Coins";
        staminacosttext.text = discountedStaminaCost + " Coins";
        fortunecosttext.text = discountedFortuneCost + " Coins";

        staminaleveltext.text = "Level: " + staminalevel;
        pickaxeleveltext.text = "Level: " + pickaxelevel;
        fortuneleveltext.text = "Level: " + fortunelevel;
        coins.text = "Coins: " + PlayerMovement.coins;
    }

    public void staminabutton()
    {
        if (PlayerMovement.coins >= discountedStaminaCost)
        {
            PlayerMovement.coins -= discountedStaminaCost;
            staminalevel++;
            PlayerMovement.fullstamina += 5;
            PlayerMovement.stamina += 5;
            stamUI.GetComponent<HealthStamUI>().UpdateStaminaUI();
            staminacost += 20;
        }
    }

    public void fortunebutton()
    {
        if (PlayerMovement.coins >= discountedFortuneCost)
        {
            PlayerMovement.coins -= discountedFortuneCost;
            fortunelevel++;
            PlayerMovement.fortune += 1;
            fortunecost += 20;
        }
    }

    public void breakingbutton()
    {
        if (PlayerMovement.coins >= discountedPickaxeCost)
        {
            PlayerMovement.coins -= discountedPickaxeCost;
            pickaxelevel++;
            PlayerMovement.breakingpower += 1;
            pickaxecost += 500;
        }
    }

    public void CloseMenu()
    {
        wg.GetComponent<Indicator>().EnableIndicator(true, 0f, "Press B to Open Shop");
        shoppanel.SetActive(false);
        otherui.SetActive(true);
    }
}