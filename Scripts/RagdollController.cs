using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] ragdollRigidbodies;
    private Collider[] ragdollColliders;
    private Animator animator;
    private CharacterController characterController;
    private ThirdPersonController thirdPersonController;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Get all rigidbodies and colliders in children (the ragdoll parts)
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Start with ragdoll disabled
        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        // Disable animator
        if (animator != null)
        {
            animator.enabled = false;
        }

        if (characterController != null)
        {
            characterController.enabled = false;
        }

        if (thirdPersonController != null)
        {
            thirdPersonController.enabled = false;
        }

        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false;
        }

        // Enable all ragdoll rigidbodies
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        // Enable all ragdoll colliders
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }
    }

    public void DisableRagdoll()
    {
        // Enable animator
        if (animator != null)
        {
            animator.enabled = true;
        }

        if (characterController != null)
        {
            characterController.enabled = true;
        }

        if (thirdPersonController != null)
        {
            thirdPersonController.enabled = true;
        }

        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = true;
        }

        // Disable all ragdoll rigidbodies
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }
        // Disable all ragdoll colliders except the main character controller
        foreach (Collider col in ragdollColliders)
        {
            // Don't disable the main character controller
            if (col != characterController)
            {
                col.enabled = false;
            }
        }
    }
}
