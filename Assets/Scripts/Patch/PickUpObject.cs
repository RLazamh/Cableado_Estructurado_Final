using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject PickedObject;  //El objeto que  hemos tomado
    public Transform interactionZone; // ponemos en la zona de la mano  XD
    public GameObject CamaraAuxiliar; //Encontrar la cámara auxiliar.
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        CamaraAuxiliar = GameObject.Find("CamAux");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(CamaraAuxiliar.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100.0f))
            {
                Debug.Log(hit.collider.name);

            }
        }
        
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {

            Debug.Log(" Cumple  condicion 1");
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(" Cumple  condicion 2");
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;  // para que no se mueva  si le chocan :D
                PickedObject.tag = "PuertoOcupado";

            }


        }

        else if (PickedObject != null) // en el el caso de que ya haya  en el puerto
        {
            Debug.Log(" Cumple  condicion 3");
           
                
                if (Input.GetMouseButtonDown(0) && Physics.Raycast(CamaraAuxiliar.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100.0f))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                    Debug.Log(" Cumple  condicion 4");
                    PickedObject.GetComponent<PickableObject>().isPickable = true;
                    PickedObject.transform.SetParent(null);
                    PickedObject.GetComponent<Rigidbody>().isKinematic = true;   //  evita  el choque
                    PickedObject.tag = "Conector";
                    PickedObject = null;
                }
            }
            
        {

        }




    }
}
