using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArmVertical : MonoBehaviour {

    public float rotateSpeed = 1.0f;

    float minRotation = -45f;
    float maxRotation =  45f;

    Vector3 currentRotation;

    void Update ()
    {
        float yMouseInput = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        
        transform.Rotate(yMouseInput *= -1, 0f, 0f);

        /* Try #1
        if (transform.rotation.eulerAngles.x > 15)
        {
            transform.rotation = Quaternion.Euler(new Vector3(14.5f, 0f, 0f));
        }
        if (transform.rotation.eulerAngles.x < -15)
        {
            transform.rotation = Quaternion.Euler(new Vector3(-14.5f, 0f, 0f));
        }
        */
       
        /* Try #2
        yMouseInput = Mathf.Clamp(yMouseInput, -90, 90);

        transform.localEulerAngles = new Vector3(-yMouseInput, 0f, 0f);
        */
        
        /* Try #3
        currentRotation = transform.localRotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(yMouseInput, minRotation, maxRotation);

        transform.localRotation = Quaternion.Euler(currentRotation);
        */
    }
}
