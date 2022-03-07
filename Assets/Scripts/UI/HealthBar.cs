using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        PlayerStats.OnLifeChange += SetCurrentHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        Debug.Log(currentHealth);
        slider.value = currentHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
}
