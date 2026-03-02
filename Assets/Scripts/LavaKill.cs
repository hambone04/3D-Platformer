using UnityEngine;

public class LavaKill : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
	private ScoreManager scoreManager;
	
	private void Start()
	{
		scoreManager = GameObject.FindWithTag("Score Manager").GetComponent<ScoreManager>();
	}
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the player
        if (other.CompareTag("Player"))
        {
			scoreManager.SubtractScore(10);
            // Get the player's CharacterController or Rigidbody to disable/enable physics
            CharacterController controller = other.GetComponent<CharacterController>();

            
            if (controller != null)
            {
                controller.enabled = false;
                other.transform.position = spawnPoint.position;
                controller.enabled = true;
            }
        }
    }
}