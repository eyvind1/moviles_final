using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {


    public bool isFlat = true;
    private Rigidbody rigid;
	// Update is called once per frame

    private void start()
    {
        rigid = GetComponent<Rigidbody>();
    }

	private void Update () {
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);

        Vector3 tilt = Input.acceleration;
        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        rigid.AddForce(tilt);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
	}
}
