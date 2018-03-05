using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform  bulletSpawn;

    public float bulletSpeed = 50f;
	
	// Update is called once per frame
	void Update () {

        // Clicked left button?
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    public void Fire()
    {
        // Create bullet from prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 5 seconds
        Destroy(bullet, 5.0f);
    }
}
