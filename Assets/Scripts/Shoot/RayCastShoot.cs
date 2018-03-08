using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour {

    public int gunDamage        = 1;      // Damage the gun will make to objects
    public float fireRate       = .25f;   // Time between two shots    
    private float nextFire;               // Needed for cooldown
    public float weaponRange    = 50f;    // How far is the weapon able to shoot
    public float hitForce       = 100f;   // will applay force to an object found by raycast
    
    public Transform gunEnd;    // point where the gun ends
    public Camera fpsCam;       // First Person Camera
    
    private LineRenderer laserLine;

    // Use this for initialization
    void Start () {

        laserLine = GetComponent<LineRenderer>();     
        
	}
	
	// Update is called once per frame
	void Update () {

        // If left mouse button is clicked 
        // and time since last shot is higher than cooldown
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;      
            
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);            
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
               laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);            
            }
        }
    }
      
}
