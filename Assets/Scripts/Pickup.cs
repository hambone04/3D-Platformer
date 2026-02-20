using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 10;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 90f;

void Update()
{
    transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
