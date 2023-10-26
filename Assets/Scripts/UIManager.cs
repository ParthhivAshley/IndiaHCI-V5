using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Block8;
    public GameObject Destination;
    public GameObject Library;
    public GameObject MAC;

    public void InputHandler(int val)
    {
        switch (val)
        {
            case 0:
                break;
            case 1:
                Destination.transform.position = Block8.transform.position;
                break;
            case 2:
                Destination.transform.position = Library.transform.position;
                break;
            case 3:
                Destination.transform.position = MAC.transform.position;
                break;
        }
    }

    private void Update()
    {
        if (Destination != null)
        {
            StartCoroutine(PathMaker.DrawPathToDestination(Destination));
        }
    }
    // Update is called once per frame
}
