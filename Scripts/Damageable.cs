using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }
}
