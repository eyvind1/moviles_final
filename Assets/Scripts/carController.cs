using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {


    //private Rigidbody rigid;
    //float dirx;

    int current = 0;
    float moveSpeed = 1.0f;
    
	// Update is called once per frame

    private void start()
    {
        //rigid = GetComponent<Rigidbody>();
    }

	private void Update () {
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        //var x = Input.acceleration.x*moveSpeed;
        //transform.Translate(x,0,0);
       
        Vector3 position = transform.position;
        var x = Input.acceleration.x*moveSpeed;
        if(transform.position.x+ x<-5)
        {
            position.x = -5;
        }
        else if(transform.position.x +x>5)
        {
            position.x =5;
        }
        else{
            position.x +=x;
        }
        transform.position=position;
        
        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
        


	}
    
}
