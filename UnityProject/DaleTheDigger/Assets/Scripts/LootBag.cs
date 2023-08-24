using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public Tile[] gemstones;
    public Tile activegem;

    GameObject worldGen;

    private void Awake()
    {
        worldGen = GameObject.Find("WorldGenerationManager");
    }
    public void RollLoot()
    {
        int coinRoll = Random.Range(0, 101);
        //Coins
        if(coinRoll >= 0) //100%
        {
            int coinAmount = Random.Range(1, 16);
            PlayerMovement.coins += coinAmount;

            worldGen.GetComponent<MeshTextAppear>().GenerateText(gameObject.transform.position, 3, "+" + coinAmount + " Coins", 25);
        }

        int bombRoll = Random.Range(0, 101);
        //Bombs
        if (bombRoll >= 50) //50%
        {
            int bombAmount = Random.Range(1, 4);
            Inventory.bombs += bombAmount;
            worldGen.GetComponent<MeshTextAppear>().GenerateText(gameObject.transform.position, 3, "+" + bombAmount + " Bombs", 25);
        }
        int gemRoll = Random.Range(0, 101);
        //Gems
        if(gemRoll >= 70) //30%
        {
            int gemAmount = Random.Range(1, 3);
            for(int i = 0; i < gemAmount; i++)
            {
                int rangem = Random.Range(0, gemstones.Length);
                activegem = gemstones[rangem];
                Inventory.Gemstonecoins += activegem.coinWorth;
                Inventory.Gemstones += 1;
                worldGen.GetComponent<MeshTextAppear>().GenerateText(gameObject.transform.position, 3, "+1 " + activegem.tileName, 25);
            }
        }
        //Artefacts
        int artRoll = Random.Range(0, 101);
        if(artRoll >= 80) //%20
        {
            int artefact = Random.Range(0, 4);
            if(artefact == 0)
            {
                Artefacts.Artefact1Upgrade();
                worldGen.GetComponent<MeshTextAppear>().GenerateText(gameObject.transform.position, 3, "You Found: " + Artefacts.Artefact1, 25);
            }
            else if(artefact == 1)
            {
                Artefacts.Artefact2Upgrade();
                worldGen.GetComponent<MeshTextAppear>().GenerateText(gameObject.transform.position, 3, "You Found: " + Artefacts.Artefact2, 25);
            }
            else if(artefact == 2)
            {
                Artefacts.Artefact3Upgrade();
                worldGen.GetComponent<MeshTextAppear>().GenerateText(gameObject.transform.position, 3, "You Found: " + Artefacts.Artefact3, 25);
            }
            else if(artefact == 3)
            {
                Artefacts.Artefact4Upgrade();
                worldGen.GetComponent<MeshTextAppear>().GenerateText(gameObject.transform.position, 3, "You Found: " + Artefacts.Artefact4, 25);
            }
        }
    }
}
