using UnityEngine;

public static class CombatActions
{
    public static GameObject ThrowGrenade(GameObject grenadePrefab, Vector3 startPosition, Vector3 targetPosition)
    {
        if (grenadePrefab != null)
        {
            GameObject grenade = Object.Instantiate(grenadePrefab, startPosition, Quaternion.identity);
            if (grenade.TryGetComponent<Rigidbody>(out var rb))
            {
                Vector3 direction = (targetPosition - startPosition).normalized;
                float throwForce = 15f;
                rb.velocity = direction * throwForce + Vector3.up * 5f;
            }
            return grenade;
        }
        return null;
    }
}
