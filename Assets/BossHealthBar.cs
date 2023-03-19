using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
	public int currentHealth;

	int maxHealth = 100;

	public Slider slider;

    private void Awake()
    {
		currentHealth = maxHealth;
		slider = GetComponent<Slider>();
		slider.maxValue = maxHealth;
		slider.value = currentHealth;
	}
    public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

	}

    public void reduceHealth(int value)
    {
		currentHealth = currentHealth - value;
		slider.value = currentHealth;

	}
}
