using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxleInfo
{
    public WheelCollider left;
    //public GameObject leftWheelMesh;
    public WheelCollider right;
    //public GameObject rightWheelMesh;
    public bool motor;
    public bool steering;
}
public class KartController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float motor = maxMotorTorque *Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach(AxleInfo a in axleInfos)
        {
            if(a.steering)
            {
                a.left.steerAngle = steering;
                a.right.steerAngle = steering;
            }
            if(a.motor)
            {
                a.left.motorTorque = motor;
                a.right.motorTorque = motor;
            }
        } 
    }
}



 
