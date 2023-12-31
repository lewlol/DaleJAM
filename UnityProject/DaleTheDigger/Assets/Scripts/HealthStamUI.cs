using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStamUI : MonoBehaviour
{
    public Slider healthSlider;
    public Slider stamSlider;
    public void UpdateHealthUI(int maxHealth, int health)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;      
    }

    public void UpdateStaminaUI()
    {
        stamSlider.maxValue = PlayerMovement.fullstamina;
        stamSlider.value = PlayerMovement.stamina;
    }
}
