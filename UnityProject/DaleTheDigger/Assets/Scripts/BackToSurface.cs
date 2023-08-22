using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSurface : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnpoint;

    public void surface()
    {
        player.transform.position = spawnpoint.transform.position;
    }
  
}
