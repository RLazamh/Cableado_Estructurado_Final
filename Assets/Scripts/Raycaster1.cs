using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster1: MonoBehaviour
{
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.cyan);

        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray, out hit) == true)
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Debug.Log("Estas apuntando a "+ hit.collider.name);           
            }
        }
    }
}
