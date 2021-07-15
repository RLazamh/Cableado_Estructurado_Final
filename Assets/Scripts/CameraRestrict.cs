using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRestrict : MonoBehaviour
{

    //[SerializeField]
    float mouseSensitivity = 1f;
    public Transform player;

    private Quaternion camRotation;
    public float lookUpMax = 60;
    public float lookUpMin = -60;

    // Update is called once per frame
    void Start(){
        camRotation = transform.localRotation;
    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera(){
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camRotation.y = mouseX * mouseSensitivity * Time.deltaTime;
        camRotation.x += mouseY * mouseSensitivity * (-1);

        Vector3 rotPlayer = player.transform.rotation.eulerAngles;
        rotPlayer.y = camRotation.x;

        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
        player.Rotate(Vector3.up * camRotation.y);

    }
}
