using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform parent;
    public Transform closedPosition;
    public float openHeight = 2.72f;
    public float slideSpeed = 2f;
    private bool isOpen = false;
    private Vector3 openPosition;

    void Start()
    {
        openPosition = closedPosition.position + new Vector3(0, openHeight, 0);
    }
    void Update()
    {
        Vector3 targetPosition = isOpen ? openPosition : closedPosition.position;
        parent.position = Vector3.MoveTowards(parent.position, targetPosition, slideSpeed * Time.deltaTime);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null && player.hasKey && Input.GetKeyDown(KeyCode.E))
            {
                player.hasKey = false;
                ToggleDoor();
            }
        }
    }
}
