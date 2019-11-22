using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    //public Vector3 initialImpulse;
    public PhotonView PV; 
    void Start()
    {
        //GetComponent<Rigidbody>().AddForce(initialImpulse, ForceMode.Impulse);
        PV= GetComponent<PhotonView>();
        GetComponent<Rigidbody>().velocity = transform.forward*70;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
