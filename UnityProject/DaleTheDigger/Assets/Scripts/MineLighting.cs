using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class MineLighting : MonoBehaviour
{

    public Light2D Light;
    public GameObject shadow;


    private void OnTriggerEnter2D(Collider2D other)
    {

        Light.intensity = 0f;
        shadow.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Light.intensity = 1f;
        shadow.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Light.intensity = 1f;
        shadow.SetActive(true);
    }

 
}
