using UnityEngine;

public class Selector : MonoBehaviour
{
    public float holdDuration = 0.5f;  // Duration to hold the touch in seconds

    private bool isTouching = false;
    private float touchStartTime;
    private Vector2 touchStartPosition;
    public PathMaker path;
    public string Tag = "Selectable";

    void Start()
    {

    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
                touchStartTime = Time.time;
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
            }
        }

        // Check if touch is not moving and held for the desired duration
        if (isTouching && Time.time - touchStartTime >= holdDuration &&
            touchStartPosition == Input.GetTouch(0).position)
        {
            // Perform the action for holding touch here
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject Child = hit.collider.gameObject;
                Transform Parent = Child.transform.parent;

                if (Parent.CompareTag(Tag) && path != null)
                {
                    path.Destination.transform.position = Parent.position;
                }
            }


        }
    }
}