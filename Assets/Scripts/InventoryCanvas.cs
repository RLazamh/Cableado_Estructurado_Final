using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    public GameObject Inventario;
    public GameObject Scroll;

    public GameObject Indications;
    InventoryManager m;

    void Start()
    {
        m = GetComponent<InventoryManager>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameObject.FindWithTag("NewObjectNULL"))
            {
                GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                activePanel();
                Indications.SetActive(false);
            }
            else
            {
                activePanel();
            }
            Indications.SetActive(false);

            
        }
    }

    public void activePanel()
    {
        Inventario.SetActive(!Inventario.activeInHierarchy);
        if (Inventario.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.None;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Scroll.SetActive(!Scroll.activeInHierarchy);
        
    }
}
