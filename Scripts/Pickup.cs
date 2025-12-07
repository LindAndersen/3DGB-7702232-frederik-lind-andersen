using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int healthModifier = 20;
    public bool isInventoryItem = false;
    public bool isWinCondition = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Damageable damageable = other.GetComponent<Damageable>();
            if (damageable != null)
            {
                if (!isInventoryItem && !isWinCondition)
                {
                    damageable.currentHealth = Mathf.Min(damageable.currentHealth + healthModifier, damageable.maxHealth);
                    Destroy(gameObject);
                }
                else if (isWinCondition)
                {
                    Canvas canvas = FindObjectOfType<Canvas>();
                    if (canvas != null)
                    {
                        canvas.ShowVictory();
                    }
                }
                else
                {
                    Player player = other.GetComponent<Player>();
                    if (player != null)
                    {
                        player.hasKey = true;
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
