using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotacionRack : MonoBehaviour
{
    Ray ray;
    public RaycastHit hit;
    public Camera cam;
    Vector3 pos;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.black);
            if (Physics.Raycast(ray, out hit, 100.0f))

            {
                Debug.Log("El objeto es: " + hit.collider.name + "-- Y su posicion " + hit.transform.position);
                Debug.Log(" Se ha  tocado antes del  golpe");
                if (hit.collider.tag == "Rack")
                {
                    Debug.Log("Condicion para rotar");
                    hit.transform.RotateAround(hit.transform.position, Vector3.up, 90.0f);
                }
            }
        }
    }
}
