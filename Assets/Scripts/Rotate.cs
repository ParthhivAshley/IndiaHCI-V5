using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float Speed = 1.0f;

    public float bobSpeed = 1.0f;    // Speed of the bobbing effect
    public float bobAmount = 1.0f;   // Amount of bobbing

    private float startY;  // Initial Y position

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // Create a rotation quaternion based on the rotation speed
        Quaternion rotation = Quaternion.Euler(0, Speed * Time.deltaTime, 0);

        // Apply the rotation to the GameObject's transform
        transform.rotation *= rotation;

        // Calculate the new Y position using a sine wave for smooth bobbing
        float newY = startY + Mathf.Sin(Time.time * bobSpeed) * bobAmount;

        // Update the position of the game object
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}