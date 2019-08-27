using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour {
	
	public static Vector2 origin= new Vector2(79.900156f,6.795984f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float px=GPS.Instance.flongitude;
		float py=GPS.Instance.flatitude;
		 
		
		Vector2 placepoint=new Vector2(px,py);
		
		var targDir=(placepoint-origin);
		var angle = Mathf.Atan2(targDir.x, targDir.y) * Mathf.Rad2Deg;
		
		Vector3 tmp = transform.eulerAngles;
		tmp.z = (GPS.Instance.fangle -(180+angle));
		transform.eulerAngles = tmp;
	
	}
}
