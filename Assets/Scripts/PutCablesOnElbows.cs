using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutCablesOnElbows : MonoBehaviour
{

    public GameObject cable,cable_t,cable_vertical;
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
            if (Physics.Raycast(ray, out hit, 150.0f))
            {
                if (hit.collider.tag == "cable_codos" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable, new Vector3(transform.position.x+0, transform.position.y + 0, transform.position.z +0.8f), Quaternion.Euler(-270, 90, 0));
                }

                if (hit.collider.tag == "cable_codos2" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable, new Vector3(transform.position.x +0, transform.position.y -0.2f, transform.position.z - 0.5f), Quaternion.Euler(-90, 0, -90));
                }
                if (hit.collider.tag == "cable_codos3" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable, new Vector3(transform.position.x-0.5f, transform.position.y+0, transform.position.z +0.2f), Quaternion.Euler(-90, 0, 0));
                }
                if (hit.collider.tag == "cable_codos4" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable, new Vector3(transform.position.x - 0.6f, transform.position.y + 0, transform.position.z + 0.2f), Quaternion.Euler(90, 0, 0));
                }
                if (hit.collider.tag == "cable_t1" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_t, new Vector3(transform.position.x-0.5f, transform.position.y + 0, transform.position.z -3f), Quaternion.Euler(-90, -90, 0));
                }
                if (hit.collider.tag == "cable_t2" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_t, new Vector3(transform.position.x +1, transform.position.y + 0, transform.position.z + 1), Quaternion.Euler(90, -90, 0));
                }
                if (hit.collider.tag == "cable_t3" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_t, new Vector3(transform.position.x  +2, transform.position.y + 0, transform.position.z -0.5f), Quaternion.Euler(-270, -180, -180));
                }
                if (hit.collider.tag == "cable_t4" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_t, new Vector3(transform.position.x - 1, transform.position.y + 0, transform.position.z+0.5f), Quaternion.Euler(90, -90, 90));
                }
                if (hit.collider.tag == "cable_vertical" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_vertical, new Vector3(transform.position.x - 0.5f, transform.position.y  +4, transform.position.z -0), Quaternion.Euler(0, -90, 0));
                }
                if (hit.collider.tag == "cable_vertical2" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_vertical, new Vector3(transform.position.x+0.5f, transform.position.y + 4, transform.position.z + 0), Quaternion.Euler(0, 90, 0));
                }
                if (hit.collider.tag == "cable_vertical3" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_vertical, new Vector3(transform.position.x + 0.5f, transform.position.y + 4, transform.position.z +0.5f), Quaternion.Euler(0, 0, 0));
                }
                if (hit.collider.tag == "cable_vertical4" && FindGameObjectInChildWithTag(active, "cable_prueba"))
                {
                    Instantiate(cable_vertical, new Vector3(transform.position.x + 0, transform.position.y + 4, transform.position.z -0.5f), Quaternion.Euler(0, 180, 0));
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
            print(gObject.name);
            Instantiate(cable, gObject.transform.position, Quaternion.identity);
            Instantiate(cable_t, gObject.transform.position, Quaternion.identity);
            Instantiate(cable_vertical, gObject.transform.position, Quaternion.identity);
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
