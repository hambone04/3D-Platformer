using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 axis = Vector3.right;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float speed = 2f;
    
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float journeyProgress = 0f;
    
    private void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + (axis.normalized * distance);
    }
    
    private void Update()
    {
        // Oscillate between 0 and 1 using PingPong
        journeyProgress = Mathf.PingPong(Time.time * speed, 1f);
        
        // Move platform between start and end positions
        transform.position = Vector3.Lerp(startPosition, endPosition, journeyProgress);
    }
}