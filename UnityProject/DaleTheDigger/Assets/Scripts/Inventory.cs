using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static int Rocks;
    public static int Ores;
    public static int Gemstones;

    public static int Rockcoins;
    public static int Orescoins;
    public static int Gemstonecoins;
    public static int Totalcoins;
    //items
    public static int bombs;

    private void Start()
    {
        Rocks = 0;
        Ores = 0;
        Gemstones = 0;
        Rockcoins = 0;
        Orescoins = 0;
        Gemstonecoins = 0;
        Totalcoins = 0;
        bombs = 3;
    }

    public static void newday()
    {
        PlayerMovement.coins += Totalcoins;
        Rocks = 0;
        Ores = 0;
        Gemstones = 0;
        Rockcoins = 0;
        Orescoins = 0;
        Gemstonecoins = 0;
        Totalcoins = 0;
    }



    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Rocks " + Rocks);
            Debug.Log("Rockcoins " + Rockcoins);
            Debug.Log("Ores " + Ores);
            Debug.Log("Orecoins " + Orescoins);
            Debug.Log("Gemcoins " + Gemstones);
            Debug.Log("Gems " + Gemstonecoins);
            Debug.Log("Cointotal " + Totalcoins);

        }
    }



}
