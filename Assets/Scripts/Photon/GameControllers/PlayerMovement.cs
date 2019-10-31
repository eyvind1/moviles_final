using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    public float movementSpeed;
    public float rotationSpeed;
    float moveSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        PV= GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine)
        {
            DeviceMovement();
            //BasicMovement();
            //BasicRotation();
        }
    }
    void BasicMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.forward*Time.deltaTime*movementSpeed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right*Time.deltaTime*movementSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward*Time.deltaTime*movementSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right*Time.deltaTime*movementSpeed);
        }


    }
    void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X")* Time.deltaTime*rotationSpeed;
        transform.Rotate(new Vector3(0,mouseX,0));
    }

    void DeviceMovement()
    {
        Vector3 position = transform.position;
        Debug.Log("Soy x: " +transform.position.x);
        Debug.Log("Soy z :" +transform.position.z);
        float x = (Input.acceleration.x*moveSpeed);
      
        if(transform.position.x==-76 )
        {
            x=x*-1;
            if(transform.position.z+ x<-20)
            {
                position.z = -20;
            }
            else if(transform.position.z +x>20)
            {
                position.z =20;
            }
            else{
                position.z +=x;
            }
            transform.position=position;
        }
		else if(transform.position.z==-76 )
        {
            if(transform.position.x+ x<-20)
            {
                position.x = -20;
            }
            else if(transform.position.x +x>20)
            {
                position.x =20;
            }
            else{
                position.x +=x;
            }
            transform.position=position;
        }
        else if(transform.position.z == 76)
        {
            x=x*-1;
            if(transform.position.x+ x<-20)
            {
                position.x = -20;
            }
            else if(transform.position.x +x>20)
            {
                position.x =20;
            }
            else{
                position.x +=x;
            }
            transform.position=position;
        }
        else if(transform.position.x == 76)
        {
            
            if(transform.position.z+ x<-20)
            {
                position.z = -20;
            }
            else if(transform.position.z +x>20)
            {
                position.z =20;
            }
            else{
                position.z +=x;
            }
            transform.position=position;
        }
        
    }
}
