using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSCene : MonoBehaviour
{
    // end stats
    public TextMeshProUGUI Daystaken;
    public TextMeshProUGUI RocksMined;
    public TextMeshProUGUI OresMined;
    public TextMeshProUGUI Gemstonesmined;
    public TextMeshProUGUI coinsearned;

    public static int Totalrocks;
    public static int TotalOres;
    public static int TotalGems;
    public static int Totalcoins;


    public GameObject fadeIn;
    public GameObject fadeOut;

    void Start()
    {
        
    }
    public static void cleartotals()
    {
        Totalrocks = 0;
        TotalOres = 0;
        TotalGems = 0;
        Totalcoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        endpog();

        
    }

    public void endpog()
    {
        Daystaken.text = "In " + NewDay.day +  " Days.";
        RocksMined.text = "You Mined " +Totalrocks+ " Rocks";
        OresMined.text = "You Mined " +TotalOres+ " Ores";
        Gemstonesmined.text = "You Mined " +TotalGems+ " Gemstones";
        coinsearned.text = "You Gained " + Totalcoins+ " Total Coins";

    }

    public void ended()
    {
        StartCoroutine(fading());
    }

    IEnumerator fading()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        fadeIn.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
