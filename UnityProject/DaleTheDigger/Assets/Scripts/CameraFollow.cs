using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(player.position.y, -296, 100), transform.position.z);
    }
}
