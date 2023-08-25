using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeathSpawnPoint;
    public GameObject otherui;
    public GameObject sleepui;
    public HealthStamUI hs;
    public void Respawn()
    {
        //clears inventory
        Inventory.deathinventory();
        otherui.SetActive(false);
        sleepui.SetActive(true);
        Player.transform.position = DeathSpawnPoint.transform.position;
    }
    public void AffectHealthUI(int mh, int h)
    {
        hs.UpdateHealthUI(mh, h);
    }
}
