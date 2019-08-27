using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {
	
	public static GPS Instance{set;get;}
	
	public string latitude;
	public string longitude;
	public string angle;
	public float flatitude;
	public float flongitude;
	public float fangle;

	private void Start(){
		Instance = this;
		DontDestroyOnLoad(gameObject);
		StartCoroutine(SLocService());
	}
	
	
	private IEnumerator SLocService()
    {
        
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.compass.enabled=true;
        Input.location.Start();
		
	
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        
        if (maxWait <= 0)
        {
            print("Timed out");
			latitude = "Timed out";
            yield break;
        }

        
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
			latitude = "Unable to determine device location";
            yield break;
        }
        else
        {
            
            latitude =("Location: " + Input.location.lastData.latitude);
			longitude =("Logitude: " + Input.location.lastData.longitude);
			angle=("Angle: " + Input.compass.magneticHeading);
			flongitude=Input.location.lastData.longitude;
			flatitude=Input.location.lastData.latitude;
			fangle=Input.compass.magneticHeading;
		}

        
    }
	
	private void Update(){
		latitude =("Location: " + Input.location.lastData.latitude);
		longitude =("Logitude: " + Input.location.lastData.longitude);
		angle=("Angle: " + Input.compass.magneticHeading);
		flongitude=Input.location.lastData.longitude;
		flatitude=Input.location.lastData.latitude;
		fangle=Input.compass.magneticHeading;
	}

	
	// Update is called once per frame
}
