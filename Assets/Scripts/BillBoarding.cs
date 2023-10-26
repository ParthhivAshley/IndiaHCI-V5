using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        // Ensure the billboard always faces the camera
        transform.LookAt(Camera.main.transform);
    }
}

