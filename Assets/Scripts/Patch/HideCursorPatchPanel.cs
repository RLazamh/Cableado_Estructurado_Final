using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursorPatchPanel : MonoBehaviour
{


    Ray ray;
    RaycastHit hit;
    public GameObject CamaraAuxiliar; //Encontrar la cámara auxiliar.


    // Start is called before the first frame update
    void Start()
    {
        CamaraAuxiliar = GameObject.Find("CamAux");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(CamaraAuxiliar.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100.0f))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Conector")
                {
                    EsconderCursor();
                }

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MostrarCursor();
        }
    }

    void EsconderCursor()
    {
        Cursor.visible = false;
    }

    void MostrarCursor()
    {
        Cursor.visible = true;
    }
} 
