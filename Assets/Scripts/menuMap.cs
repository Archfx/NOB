using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMap : MonoBehaviour {

    private float rot=.5f;
	
	
	// Update is called once per frame
	void Update ()
    {
      
        transform.Rotate(0, rot, 0);
        

    }
}
