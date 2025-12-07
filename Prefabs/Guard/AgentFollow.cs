using UnityEngine;
using UnityEngine.AI;

public class AgentFollow : MonoBehaviour
{
    public Transform target;
    public float detectionRadius = 30f;
    public float grenadeRadius = 15f;
    public float throwCooldown = 5f;
    public GameObject grenadePrefab;

    private float lastThrowTime = -Mathf.Infinity;
    private NavMeshAgent agent;
    private Animator animator;
    private RagdollController ragdollController;
    private Damageable damageable;
    private bool isDead = false;

    private 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ragdollController = GetComponent<RagdollController>();
        damageable = GetComponent<Damageable>();
        gameObject.AddComponent<BoxCollider>();
    }

    void Update()
    {
        if (isDead) return;

        if (target != null && agent != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= detectionRadius)
            {
                agent.SetDestination(target.position);
                if (distance < grenadeRadius && Time.time - lastThrowTime >= throwCooldown)
                {
                    lastThrowTime = Time.time;
                    animator.SetTrigger("doThrow");
                    CombatActions.ThrowGrenade(grenadePrefab, transform.position + Vector3.up * 1.5f, target.position);
                }
            }
            else
            {
                agent.ResetPath();
            }
        }

        if (animator != null)
        {
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("speedPercent", speedPercent, 0.1f, Time.deltaTime);
        }

        // Check for death
        if (damageable.currentHealth <= 0 && ragdollController != null)
        {
            ragdollController.EnableRagdoll();
            isDead = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grenadeRadius);
    }
}
