using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class MineLighting : MonoBehaviour
{
    public Light2D Light;
    public GameObject shadow;
    public GameObject helmet;

    private bool inDarkArea = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inDarkArea = true;
            UpdateLighting();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inDarkArea = false;
            UpdateLighting();
        }
    }

    private void UpdateLighting()
    {
        if (inDarkArea)
        {
            Light.intensity = 0f;
            shadow.SetActive(false);
            helmet.SetActive(true);
        }
        else
        {
            Light.intensity = 1f;
            shadow.SetActive(true);
            helmet.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateLighting();
    }
}