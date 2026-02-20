using UnityEngine;

public class LavaKill : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the player
        if (other.CompareTag("Player"))
        {
            // Get the player's CharacterController or Rigidbody to disable/enable physics
            CharacterController controller = other.GetComponent<CharacterController>();
            
            if (controller != null)
            {
                controller.enabled = false;
                other.transform.position = spawnPoint.position;
                controller.enabled = true;
            }
            else
            {
                // If using Rigidbody instead
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                }
                other.transform.position = spawnPoint.position;
            }
        }
    }
}