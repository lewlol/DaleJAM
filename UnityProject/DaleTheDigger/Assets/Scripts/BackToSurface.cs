using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSurface : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnpoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            surface();
        }
    }
    public void surface()
    {
        player.transform.position = spawnpoint.transform.position;
    }
  
}
