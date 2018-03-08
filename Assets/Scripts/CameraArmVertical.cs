using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArmVertical : MonoBehaviour {

    public float rotateSpeed = 1.0f;

    void Update ()
    {
        float yMouseInput = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

        transform.Rotate(yMouseInput *= -1, 0f, 0f);

        /*
        if (transform.rotation.eulerAngles.x <= 15)
        {
            transform.Rotate(yMouseInput *= -1, 0.0f, 0.0f);
        }
        if (transform.rotation.eulerAngles.x >= -15)
        {
            transform.Rotate(yMouseInput *= -1, 0.0f, 0.0f);
        }
        */
    }
}
