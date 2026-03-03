using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 10;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 90f;

    private bool collected = false;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            ScoreManager.Instance.AddScore(scoreValue);
            other.GetComponent<VoicelineManager>()?.PlayPickupVoiceline();
            Destroy(gameObject);
        }
    }
}