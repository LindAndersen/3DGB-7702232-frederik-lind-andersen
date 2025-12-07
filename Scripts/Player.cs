using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject grenadePrefab;
    private RagdollController ragdollController;
    private Canvas canvas;
    private Damageable damageable;

    void Start()
    {
        damageable = GetComponent<Damageable>();
        ragdollController = GetComponent<RagdollController>();
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas != null)
        {
            canvas.SetHealth((float)damageable.currentHealth / damageable.maxHealth);
        }

        // Check for death
        if (damageable.currentHealth <= 0 && ragdollController != null)
        {
            ragdollController.EnableRagdoll();
            canvas.ShowDefeat();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            CombatActions.ThrowGrenade(grenadePrefab, transform.position + Vector3.up * 1.5f, transform.position + transform.forward * 10f);
        }
    }
}
