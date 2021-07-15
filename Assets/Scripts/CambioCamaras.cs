using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamaras : MonoBehaviour {

    public Camera MainCamera;
    public Camera FPS_Camera;

    // Use this for initialization
    void Start () {

        MainCamera.enabled = true;
        FPS_Camera.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("f1"))
        {
            MainCamera.enabled = true;
            FPS_Camera.enabled = false;
        }

        if (Input.GetButtonDown("f2"))
        {
            MainCamera.enabled = false;
            FPS_Camera.enabled = true;
        }
    }
}
