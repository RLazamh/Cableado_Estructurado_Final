using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class inputObject : MonoBehaviour
{
    // Start is called before the first frame update


    Ray ray;
    public RaycastHit hit;
    public GameObject newgameObject, padrePatch, patch2;
    public Camera cam;
    Vector3 pos;


    // Update is called once per frame
    void Update()
    {
        //pos = GameObject.FindGameObjectsWithTag("Slot").transform.position;
        if (Input.GetButtonDown("Patch1"))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray, out hit, 100.0f))

            {
                Debug.Log("El objeto es: " + hit.collider.name + "-- Y su posicion " + hit.transform.position);
                Debug.Log(" Se ha  tocado antes del  golpe");
                if (hit.collider.tag == "Slot")
                {
                    GameObject cuboTemp = Instantiate(newgameObject, hit.transform.position, Quaternion.Euler(-90, 0, 0));
                    Debug.Log(" Se ha  colcado");
                    cuboTemp.transform.parent = padrePatch.transform;
                    //Debug.Log(" Se ha  tocado");
                    //Vector3 dimension = newgameObject.transform.localScale;
                    //newgameObject.transform.localScale = dimension;
                    //Instantiate(newgameObject, hit.point, Quaternion.Euler(90,0,0) );
                    hit.collider.tag = "SlotOcupado";

                }

            }
        }
        else if (Input.GetButtonDown("Patch2"))

        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray, out hit, 100.0f))

            {
                Debug.Log("El objeto es: " + hit.collider.name + "-- Y su posicion " + hit.transform.position);
                Debug.Log(" Se ha  tocado antes del  golpe");
                if (hit.collider.tag == "Slot2") //Prueba
                {
                    GameObject cuboTemp2 = Instantiate(patch2, hit.transform.position, Quaternion.Euler(-90, 0, 0));
                    Debug.Log(" Se ha  colcado"); 
                    cuboTemp2.transform.parent = padrePatch.transform;
                    //Debug.Log(" Se ha  tocado");
                    //Vector3 dimension = newgameObject.transform.localScale;
                    //newgameObject.transform.localScale = dimension;
                    //Instantiate(newgameObject, hit.point, Quaternion.Euler(90,0,0) );
                    hit.collider.tag = "SlotOcupado";
                }


            }
        }
    }
}







        



        
    

