using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeathSpawnPoint;
    public GameObject otherui;
    public GameObject sleepui;
 
    void Update()
    {
        if(PlayerMovement.health <= 0)
        {
            Respawn();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            PlayerMovement.health = 0;
        }


    }

    public void Respawn()
    {
        //clears inventory
        Inventory.deathinventory();
        otherui.SetActive(false);
        sleepui.SetActive(true);
        Player.transform.position = DeathSpawnPoint.transform.position;
    }
    

}
