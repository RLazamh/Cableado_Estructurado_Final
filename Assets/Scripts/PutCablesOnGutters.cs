using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCablesOnGutters : MonoBehaviour
{

    public GameObject cable,cable_horizontal;
    List<GameObject> currentGutters = new List<GameObject>();
    
    public Camera cam;
    public Camera FPS_Camera;
    Ray ray, ray2;
    RaycastHit hit;
    public GameObject active;

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0)) 
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            ray2 = FPS_Camera.ScreenPointToRay(Input.mousePosition);
            ray = ray2;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "cable" && FindGameObjectInChildWithTag(active,"cable_prueba"))
                {
                    Instantiate(cable, new Vector3(transform.position.x - 8, transform.position.y + 0, transform.position.z + 0), Quaternion.Euler(0, 270, 0));
                }
                if (hit.collider.tag == "cable_horizontal" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_horizontal, new Vector3(transform.position.x+0 , transform.position.y + 0, transform.position.z+5), Quaternion.Euler(0, 0, 0));
                }
            }

                
        }
    }

    void OnTriggerEnter(Collider col)
    {

        // Add the GameObject collided with to the list.
        currentGutters.Add(col.gameObject);
   
        // Print the entire list to the console.
        foreach (GameObject gObject in currentGutters)
        {
            print (gObject.name);
            Instantiate(cable,gObject.transform.position, Quaternion.identity);
            Instantiate(cable_horizontal, gObject.transform.position, Quaternion.identity);
        }
    }
    

    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }
}
