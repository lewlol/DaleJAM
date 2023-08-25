using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    public float hoverScaleIncrease = 1.1f;
    public Color hoverTextColor = Color.blue;
    public float shakeIntensity = 0.1f;
    public float shakeSpeed = 5f;
    public Texture2D pickaxecorsortexture;

    private Vector3 originalScale;
    public TextMeshProUGUI buttonText;
    private Color originalTextColor;

    private bool isHovering = false;

    private void Start()
    {
        originalScale = transform.localScale;
        
        originalTextColor = buttonText.color;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseEnter()
    {
        isHovering = true;
        buttonText.color = hoverTextColor;

        transform.localScale = originalScale * hoverScaleIncrease;
        Cursor.SetCursor(pickaxecorsortexture, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        isHovering = false;
        buttonText.color = originalTextColor;
        transform.localScale = originalScale;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (isHovering)
        {
            
            float shakeAmount = Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity;
            transform.position = originalScale + new Vector3(shakeAmount, shakeAmount, 0f);
        }
    }
}