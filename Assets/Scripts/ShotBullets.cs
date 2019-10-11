using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        CmdFire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        
        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward*70;
    
        
        
        StartCoroutine("Wait3Sec");
        // Spawn the bullet on the Clients
        //NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        //Destroy(bullet, 2.0f);
    }
    public IEnumerator Wait3Sec(){
        yield return new WaitForSeconds(10f);
        CmdFire();

        Destroy(bullet, 8.0f);
    }
}
