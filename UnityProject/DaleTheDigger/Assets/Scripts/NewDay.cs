using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDay : MonoBehaviour
{
    public GameObject sleepui;
    public GameObject otherui;
    public static int day;
    public GameObject Player;

    public TextMeshProUGUI Endofday;
    public TextMeshProUGUI RockTotal;
    public TextMeshProUGUI RockCoins;
    public TextMeshProUGUI OreTotal;
    public TextMeshProUGUI OreCoins;
    public TextMeshProUGUI GemTotal;
    public TextMeshProUGUI GemCoins;
    public TextMeshProUGUI coinstotal;

    public TextMeshProUGUI Playercoins;

    public GameObject worldGen;

    public HealthStamUI hs;
    bool inRadius;

    public GameObject fadeIn;
    public GameObject fadeOut;
    void Start()
    {
        day = 1;
    }

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
            inRadius = true;
            worldGen.GetComponent<Indicator>().EnableIndicator(true, 0f, "Press B to Sleep");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRadius = false;
            worldGen.GetComponent<Indicator>().DisableIndicator();
        }
    }

    void enterhome()
    {
        if (inRadius && Input.GetKeyDown(KeyCode.B))
        {
            sleepui.SetActive(true);
            otherui.SetActive(false);
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }

    void daystats()
    {
        Endofday.text = "End of day " + day;
        RockTotal.text = " Rocks Mined: " + Inventory.Rocks;
        RockCoins.text = Inventory.Rockcoins+ " Coins Earned";
        OreTotal.text = " Ores Mined: " + Inventory.Ores;
        OreCoins.text = Inventory.Orescoins + " Coins Earned";
        GemTotal.text = " Gems Mined: " + Inventory.Gemstones;
        GemCoins.text = Inventory.Gemstonecoins + " Coins earned";
        coinstotal.text = " Total coins earned: " + Inventory.Totalcoins;
    }

    public void sleep()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        fadeIn.SetActive(false);

        //whatever code to regenerate world
        day++;
        Inventory.newday();
        otherui.SetActive(true);
        sleepui.SetActive(false);
        PlayerMovement.stamina = PlayerMovement.fullstamina;
        Player.GetComponent<PlayerMovement>().HealPlayer();


        hs.UpdateStaminaUI();
        hs.UpdateHealthUI(Player.GetComponent<PlayerMovement>().maxHealth, Player.GetComponent<PlayerMovement>().health);

        WorldGeneration wg = GameObject.Find("WorldGenerationManager").GetComponent<WorldGeneration>();
        worldGen.GetComponent<DayCounter>().AddDayCount(day.ToString());
        //Delete Previous World Gen
        foreach (GameObject tile in wg.tiles)
        {
            Destroy(tile);
        }
        wg.NewDay();
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        Player.GetComponent<CapsuleCollider2D>().enabled = true;
        Player.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(0.5f);
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);

    }
}
