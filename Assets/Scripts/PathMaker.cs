using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PathMaker : MonoBehaviour
{
    public bool SelView = false;
    private GameObject Person;
    private GameObject LnRender;
    [SerializeField]
    private static Transform Character;
    [SerializeField]
    private static LineRenderer Path;
    [SerializeField]
    private static float PathHeight = 1.25f;
    [SerializeField]
    private static float PathUpdateSpeed = 0.5f;

    [SerializeField]
    private GameObject Entrance;
    [SerializeField]
    private GameObject Hubble;
    [SerializeField]
    private GameObject Library;
    [SerializeField]
    private GameObject FormerIT;
    [SerializeField]
    private GameObject MAC;
    [SerializeField]
    private GameObject Enrollment;
    [SerializeField]
    private GameObject FoodCourt;
    [SerializeField]
    private GameObject ChaiGaram;
    [SerializeField]
    private GameObject Frisco;
    [SerializeField]
    private GameObject Geetha;
    [SerializeField]
    private GameObject Tulips;
    [SerializeField]
    private GameObject MDCGuestHouse;

    [SerializeField]
    private GameObject Block1;
    [SerializeField]
    private GameObject Block2;
    [SerializeField]
    private GameObject Block3;
    [SerializeField]
    private GameObject Block4;
    [SerializeField]
    private GameObject Block5;
    [SerializeField]
    private GameObject Block6;
    [SerializeField]
    private GameObject Block7;
    [SerializeField]
    private GameObject Block8;
    [SerializeField]
    private GameObject Block9;
    [SerializeField]
    private GameObject Block10;
    [SerializeField]
    private GameObject Block11;
    [SerializeField]
    public GameObject Destination;

    private NavMeshTriangulation Triangulation;
    private Coroutine DrawPathCoroutine;
    private float speed = 2.0f;
    private bool isTouching = false;
    private float touchStartTime;
    private Vector2 touchStartPosition;
    public PathMaker path;
    public string Tag = "Selectable";
    public float holdDuration = 1.0f;

    private void Start()
    {
        LnRender = GameObject.Find("LineRenderer");
        Person = GameObject.Find("Character");
        Character = Person.transform;
        Path = LnRender.GetComponent<LineRenderer>();

    }
    void Update()
    {
        if (Destination != null)
        {
            StartCoroutine(PathMaker.DrawPathToDestination(Destination));
        }

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
        if (isTouching && Time.time - touchStartTime >= holdDuration && touchStartPosition == Input.GetTouch(0).position && SelView)
        {
            // Perform the action for holding touch here
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject Child = hit.collider.gameObject;
                Transform Parent = Child.transform.parent;

                //Destination.transform.position = Parent.position;

                if (Parent.CompareTag(Tag) && path != null)
                {
                    Destination.transform.position = Parent.position;
                }
            }


        }
    }


    public static IEnumerator DrawPathToDestination(GameObject Destination)
    {
        WaitForSeconds Wait = new WaitForSeconds(PathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

        if(NavMesh.CalculatePath(Character.position, Destination.transform.position, NavMesh.AllAreas, path))
        {
            Path.positionCount = path.corners.Length;
            
            for(int i = 0; i < path.corners.Length; i++)
            {
                Path.SetPosition(i, path.corners[i]+Vector3.up * PathHeight);

            }
        }
        else
        {
            Debug.Log("Character Not in NavMesh");
        }
        yield return Wait;
    }


    public void InputHandler(int val)
    {
        switch (val)
        {
            case 0:
                Destination.transform.position = Character.position;
                break;
            case 1:
                Destination.transform.position = Entrance.transform.position;
                Debug.Log("Entrance");
                break;
            case 2:
                Destination.transform.position = Enrollment.transform.position;
                Debug.Log("Enrollment");
                break;
            case 3:
                Destination.transform.position = Hubble.transform.position;
                Debug.Log("Hubble");
                break;
            case 4:
                Destination.transform.position = MAC.transform.position;
                Debug.Log("MAC");
                break;
            case 5:
                Destination.transform.position = Library.transform.position;
                Debug.Log("Library");
                break;
            case 6:
                Destination.transform.position = FormerIT.transform.position;
                Debug.Log("IT Tower");
                break;
            case 7:
                Destination.transform.position = FoodCourt.transform.position;
                Debug.Log("Food Court");
                break;
            case 8:
                Destination.transform.position = ChaiGaram.transform.position;
                Debug.Log("Chai Garam");
                break;
            case 9:
                Destination.transform.position = Frisco.transform.position;
                Debug.Log("Frisco");
                break;
            case 10:
                Destination.transform.position = Geetha.transform.position;
                Debug.Log("Geetha");
                break;
            case 11:
                Destination.transform.position = Tulips.transform.position;
                Debug.Log("Tulips");
                break;
            case 12:
                Destination.transform.position = MDCGuestHouse.transform.position;
                Debug.Log("Guest House");
                break;
            case 13:
                Destination.transform.position = Block1.transform.position;
                Debug.Log("1");
                break;
            case 14:
                Destination.transform.position = Block2.transform.position;
                Debug.Log("2");
                break;
            case 15:
                Destination.transform.position = Block3.transform.position;
                Debug.Log("3");
                break;
            case 16:
                Destination.transform.position = Block4.transform.position;
                Debug.Log("4");
                break;
            case 17:
                Destination.transform.position = Block5.transform.position;
                Debug.Log("5");
                break;
            case 18:
                Destination.transform.position = Block6.transform.position;
                Debug.Log("6");
                break;
            case 19:
                Destination.transform.position = Block7.transform.position;
                Debug.Log("7");
                break;
            case 20:
                Destination.transform.position = Block8.transform.position;
                Debug.Log("8");
                break;
            case 21:
                Destination.transform.position = Block9.transform.position;
                Debug.Log("9");
                break;
            case 22:
                Destination.transform.position = Block10.transform.position;
                Debug.Log("10");
                break;
            case 23:
                Destination.transform.position = Block11.transform.position;
                Debug.Log("11");
                break;
        }
    }
}

