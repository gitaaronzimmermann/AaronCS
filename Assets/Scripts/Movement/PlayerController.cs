using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 0.2f;
    public float rotateSpeed = 1f;

	void Update () {

        #region Controller
        // Keyboard Input - WASD
        float xInputTranslate = Input.GetAxis("Horizontal") * moveSpeed;
        float zInputTranslate = Input.GetAxis("Vertical") * moveSpeed;

        // Mouse Input
        float xMouseInput = Input.GetAxis("Mouse X") * rotateSpeed;
        // float yMouseInput = Input.GetAxis("Mouse Y") * rotateSpeed;

        // Movement
        transform.Translate(xInputTranslate, 0.0f, zInputTranslate);

        // Rotation
        transform.Rotate(0.0f, xMouseInput, 0.0f);
        #endregion
        
    }
}
