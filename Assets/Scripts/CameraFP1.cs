using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFP1 : MonoBehaviour {


    public Camera FPSCamera;

    public float horizontalSpeed;
    public float verticalSpeed;

    float h;
    float v;
	
	// Update is called once per frame
	void Update () {

        h = Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
        v = Input.GetAxis("Mouse Y") * verticalSpeed;

        transform.Rotate (0,h,0);
        FPSCamera.transform.Rotate (-v, 0, 0);

    }
}
