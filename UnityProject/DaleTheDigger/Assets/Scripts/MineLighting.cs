using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class MineLighting : MonoBehaviour
{

    public Light2D Light;
    public GameObject shadow;
    public GameObject helmet;


    private void OnTriggerEnter2D(Collider2D other)
    {

        Light.intensity = 0f;
        shadow.SetActive(false);
        helmet.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Light.intensity = 1f;
        shadow.SetActive(true);
        helmet.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Light.intensity = 1f;
        shadow.SetActive(true);
        helmet.SetActive(false);
    }

 
}
