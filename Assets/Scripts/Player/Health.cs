using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    int maxHealth = 100;

    private PlayerHealthBar playerHealthBar;
    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

        var healthBar = GameObject.FindWithTag("PlayerHealth");
        playerHealthBar = healthBar.GetComponent<PlayerHealthBar>();
    }
    public void TakeDamage(int damage)
    {

        currentHealth = playerHealthBar.currentHealth;
        if (playerHealthBar.currentHealth <= 0)
        {
            return;
        }

        playerHealthBar.reduceHealth(damage);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                dead = true;
            }
        }
    }
}