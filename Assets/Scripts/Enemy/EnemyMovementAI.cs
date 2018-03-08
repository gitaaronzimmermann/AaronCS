using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour {

    #region Var's
    public float enemySpeed    = 5.0f;  // Enemy MoveSpeed
    public float rotationSpeed = 10.0f; // Enemy RotationSpeed
    public bool trigger;                // true: player in trigger / false: Player not in trigger
    public float maxDistance = 0.0f;

    public Transform target;            // Player
    private Transform myTransform;      // Enemy 
    #endregion


    private void Awake()
    {
        // Find Enemy transform
        myTransform = transform;
    }

    #region TriggerBox
    // Checks if Player enters enemy trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            target = go.transform;

            trigger = true;            
        }
    }

    // Checks if Player leaves enemy trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = false;
        }
    }
    #endregion


    // Update is called once per frame
    void Update () {

        // Player is in trigger - go follow him!
        if (trigger == true)
        {
            // Look at Target
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

            // Move to target
            if (Vector3.Distance(target.position, myTransform.position) > maxDistance)
            {
                myTransform.position += myTransform.forward * enemySpeed * Time.deltaTime;
            }
        }

        // Player is not in trigger - do not move
        if (trigger == false)
        {
            return;
        }
		
	}
}
