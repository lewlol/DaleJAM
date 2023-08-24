using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public TextMeshProUGUI indicatorText;

    public void EnableIndicator(bool forever, float time, string text)
    {
        indicatorText.enabled = true;
        indicatorText.text = text;

        if(!forever)
            StartCoroutine(TurnOffIndicator(time));
    }
    public void DisableIndicator()
    {
        indicatorText.enabled = false;
    }

    IEnumerator TurnOffIndicator(float time)
    {
        yield return new WaitForSeconds(time);
        DisableIndicator();
    }
}
