using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDay : MonoBehaviour
{


    public GameObject sleepprompt;
    public GameObject sleepui;
    public GameObject otherui;
    public static int day;

    public TextMeshProUGUI Endofday;
    public TextMeshProUGUI RockTotal;
    public TextMeshProUGUI RockCoins;
    public TextMeshProUGUI OreTotal;
    public TextMeshProUGUI OreCoins;
    public TextMeshProUGUI GemTotal;
    public TextMeshProUGUI GemCoins;
    public TextMeshProUGUI coinstotal;

    public TextMeshProUGUI Playercoins;
        





    void Start()
    {
        day = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Playercoins.text = "Coins " + PlayerMovement.coins;
        enterhome();
        daystats();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sleepprompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sleepprompt.SetActive(false);
        }
    }

    void enterhome()
    {
        if (sleepprompt.activeSelf && Input.GetKeyDown(KeyCode.B))
        {
            sleepui.SetActive(true);
            otherui.SetActive(false);

        }
    }

    void daystats()
    {
        Endofday.text = "End of day " + day;
        RockTotal.text = "Rocks Mined " + Inventory.Rocks;
        RockCoins.text = Inventory.Rockcoins+ " Coins Earned";
        OreTotal.text = "Ores Mined " + Inventory.Ores;
        OreCoins.text = Inventory.Orescoins + " Coins Earned";
        GemTotal.text = "Gems Mined " + Inventory.Gemstones;
        GemCoins.text = Inventory.Gemstonecoins + " Coins earned";
        coinstotal.text = "Total coins earned " + Inventory.Totalcoins;
    }

    public void sleep()
    {
        //whatever code to regenerate world
        day++;
        Inventory.newday();
        otherui.SetActive(true);
        sleepui.SetActive(false);
    }


}
