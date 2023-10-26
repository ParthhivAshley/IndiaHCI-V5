using UnityEngine;

public class SimpleLerp : MonoBehaviour
{
    public Transform zoomedOutView;
    public Transform zoomedInView;

    public PathMaker Path;

    public Camera Camera;

    public GameObject OutButton;
    public GameObject InButton;

    public float lerpSpeed = 2.0f;

    private float lerpProg = 0.0f;
    private bool zoomOut;
    private bool zoomIn;

    void Start()
    {
        //InButton.SetActive(false);
        //OutButton.SetActive(true);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject Child = hit.collider.gameObject;
                Transform Parent = Child.transform.parent;
                Debug.Log(Parent.tag);
                Debug.Log(Child);
            }
        }

        if (zoomOut)
        {
            // Check if the target position is set
            if (zoomedOutView != null)
            {
                // Calculate the lerp amount based on the lerpSpeed
                float lerpAmount = lerpSpeed * Time.deltaTime;

                // Lerp from the initial position to the target position
                Camera.transform.position = Vector3.Lerp(Camera.transform.position, zoomedOutView.position, lerpAmount);
                lerpProg += lerpAmount;

                if (lerpProg >= 1.5f)
                {
                    lerpProg = 1.0f;
                    zoomOut = false;
                }
            }
        }

        if (zoomIn)
        {
            // Check if the target position is set
            if (zoomedInView != null)
            {
                // Calculate the lerp amount based on the lerpSpeed
                float lerpAmount = lerpSpeed * Time.deltaTime;

                // Lerp from the initial position to the target position
                Camera.transform.position = Vector3.Lerp(Camera.transform.position, zoomedInView.position, lerpAmount);
                lerpProg += lerpAmount;

                if (lerpProg >= 1.5f)
                {
                    lerpProg = 1.0f;
                    zoomIn = false;
                }
            }
        }
    }

    public void ZoomOut()
    {
        zoomOut = true;
        lerpProg = 0.0f;
        //OutButton.SetActive(false);
        //InButton.SetActive(true);
        Path.SelView = true;
    }

    public void ZoomIn() 
    {
        lerpProg = 0.0f;
        zoomIn = true;
        //OutButton.SetActive(true);
        //InButton.SetActive(false);
        Path.SelView = false;
    }
}