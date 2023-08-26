using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSCene : MonoBehaviour
{
    // end stats
    public TextMeshProUGUI Daystaken;
    public TextMeshProUGUI RocksMined;
    public TextMeshProUGUI OresMined;
    public TextMeshProUGUI Gemstonesmined;
    public TextMeshProUGUI chestsopened;

    public static int Totalrocks;
    public static int TotalOres;
    public static int TotalGems;
    public static int TotalChests;
        



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endpog();
    }

    public void endpog()
    {
        Daystaken.text = "You took " + NewDay.day +  " Days.";
        RocksMined.text = "You Mined" + " Rocks";
        OresMined.text = "You Mined" + " Ores";
        Gemstonesmined.text = "You Mined" + " Gemstones";
        chestsopened.text = "You Opened" + "Loot Chests";

    }

}
