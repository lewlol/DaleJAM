using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    public TextMeshProUGUI dayCount;

    public void AddDayCount(string day)
    {
        dayCount.text = "Day " + day;
    }
}
