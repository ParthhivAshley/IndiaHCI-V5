using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using TMPro;
using UnityEngine.AI;


public class Postioner : MonoBehaviour
{
    public TMP_Text GpsStatus;
    public TMP_Text latitudeData;
    public TMP_Text longitudeData;
    public TMP_Text UCSData;
    public Vector3 UCSConversion;
    public Vector3 XYZ;

    public Transform Player;

    float lat;
    float lng;
    Vector2 origin = new Vector2(30.41650f, 77.96850f); //0,0 is at Gandhi Chowk

    private NavMeshAgent agent;



    public bool isUpdating;
    public bool updateLocation;

    private void Start()
    {
        GPSEncoder.SetLocalOrigin(origin);
        /*
        Sets Gandhi Chowk at 0,0 geographically in lat/lng
        Thus further conversion will be relative to this <should>
        */

        // lat = 30.1470F;
        // lng = 77.9682F;
        agent = GetComponent<NavMeshAgent>();
        Player.position = new Vector3(-4.18f, -1.63f, 68.5f);

        Debug.Log(GPSEncoder.GPSToUCS(30.41717f, 77.96838f));
        Debug.Log(GPSEncoder.GPSToUCS(30.41713f, 77.96844f));
    }


    private void Update()
    {
        if (agent.isOnNavMesh)
        {
            if (!isUpdating)
            {
                StartCoroutine(GetLocation());
                isUpdating = !isUpdating;
            }

            Player.position = XYZ;

            //.position = new Vector3(5.5f, 1.4f, 0f);


        }

        //if (!agent.isOnNavMesh)
        //{
         //   NavMeshHit hit;
         //   if (NavMesh.SamplePosition(agent.transform.position, out hit, 5.0f, NavMesh.AllAreas))
         //   {
          //      Debug.Log(hit.position.ToString());
         //       agent.Warp(hit.position);
                //Player.position = hit.position;
         //   }
       // }

    }


    IEnumerator GetLocation()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(10);

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            GpsStatus.text = "Timed out";
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GpsStatus.text = "Location Unavailable | Last Known Location:";
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            GpsStatus.text = "Running";
            latitudeData.text = Input.location.lastData.latitude.ToString();
            // lat = (float)Input.location.lastData.latitude;
            longitudeData.text = Input.location.lastData.longitude.ToString();
            // lng = (float)Input.location.lastData.longitude;

            UCSConversion = GPSEncoder.GPSToUCS((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude);

            UCSData.text = UCSConversion.ToString();
            XYZ[0] = UCSConversion[0];
            XYZ[1] = 2  .21f;
            XYZ[2] = UCSConversion[2];

            yield return new WaitForSeconds(1);
        }

        // Stop service if there is no need to query location updates continuously
        isUpdating = !isUpdating;
        Input.location.Stop();
    }
}