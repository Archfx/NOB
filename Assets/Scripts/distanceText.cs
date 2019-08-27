using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distanceText : MonoBehaviour {
    private GameObject distanceTextObject;
    private double distance;
    public static Vector2 origin = new Vector2(79.900156f, 6.795984f);

    private bool setOriginalValues = true;

    private Vector3 targetPosition;
    private Vector3 originalPosition;
    // Use this for initialization
    void Start () {
        distanceTextObject = GameObject.FindGameObjectWithTag("distanceText");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.location.isEnabledByUser)
        {
            float px = GPS.Instance.flongitude;
            float py = GPS.Instance.flatitude;
            Calc(79.900156f, 6.795984f, px, py);
        }
    }

    public void Calc(float lat1, float lon1, float lat2, float lon2)
    {

        var R = 6378.137; // Radius of earth in KM
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * c;
        distance = distance * 1000f; // meters
                                     //set the distance text on the canvas

        distanceTextObject.GetComponent<Text>().text = "Distance: " + Math.Round(distance,2)+" m";
        Debug.Log(Math.Round(distance, 2));
        //convert distance from double to float
        float distanceFloat = (float)distance;
        //set the target position of the ufo, this is where we lerp to in the update function
        targetPosition = originalPosition - new Vector3(0, 0, distanceFloat * 12);
        //distance was multiplied by 12 so I didn't have to walk that far to get the UFO to show up closer

    }
}
