using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isPickable = true;


    public void OnTriggerEnter(Collider other) //Cuando el cubo entre dentro  del triger  dectecta la colicion
    {
        if (other.tag == "puerto")
        {

            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject; // objecttopick estan dentro  del otro  script estamos  buscando en el padre
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "puerto")
        {
            other.GetComponent<PickUpObject>().ObjectToPickUp = null;
        }
    }
}
