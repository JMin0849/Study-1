using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth;
    public int maxHealth = 5;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void DamagePlayer()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
