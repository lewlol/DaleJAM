using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }
}
