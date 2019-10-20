using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float time = 1f;
    public float repeatTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",time,repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        bullet = Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward*70;
        Destroy(bullet,8.0f);
    }
}
