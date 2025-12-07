using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] public AudioClip explosionSound;
    public float explosionRadius = 5f;
    public float minimumFuseTime = 3f;
    
    private float startTime;
    private Collider grenadeCollider;
    private float waitTime = 0.2f;
    private bool hasCollided = false;
    void Start()
    {
        startTime = Time.time;
        grenadeCollider = GetComponent<Collider>();
        grenadeCollider.isTrigger = true;
    }

    void Update()
    {
        if ((Time.time - startTime) > waitTime)
        {
            grenadeCollider.isTrigger = false;
        }

        // Check if it's time to explode after collision
        if (hasCollided && (Time.time - startTime) >= minimumFuseTime)
        {
            Explode();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
    }

    private void Explode()
    {
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            Debug.Log("Grenade hit: " + hitCollider.name);
            Damageable damageable = hitCollider.GetComponent<Damageable>();
            if (damageable != null)
            {
                Debug.Log("Applying damage to: " + hitCollider.name);
                damageable.currentHealth -= 30;
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
