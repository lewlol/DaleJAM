using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UiInfoPog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hoverText; // Reference to the TextMeshProUGUI component
    public string hovertext;

    private void Start()
    {
        hoverText.gameObject.SetActive(false); // Hide the text initially
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.text = hovertext;
        hoverText.gameObject.SetActive(true); // Show the text when the mouse hovers over the UI element
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.gameObject.SetActive(false); // Hide the text when the mouse exits the UI element
    }
}