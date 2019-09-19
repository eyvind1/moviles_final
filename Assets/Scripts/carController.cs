using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {


    //private Rigidbody rigid;
    //float dirx;
    float moveSpeed = 0.5f;
	// Update is called once per frame

    private void start()
    {
        //rigid = GetComponent<Rigidbody>();
    }

	private void Update () {
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        
        transform.Translate(Input.acceleration.x*moveSpeed,0,0);
        
        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
        


	}
    
}
