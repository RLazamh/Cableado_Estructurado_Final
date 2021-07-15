using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollider : MonoBehaviour
{
    InventoryManager m;
    // Start is called before the first frame update

    void Start()
    {
        m = GetComponent<InventoryManager>();
        addGutter();
        
        
        
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider col)
    {
        if (col.GetComponent<InventoryObjectR>() != null)
        {
            InventoryObjectR i = col.GetComponent<InventoryObjectR>();
            m.AddElements(i.id, i.quantity);
            Destroy(col.gameObject);
        }		
	}

    void addGutter(){

        if( GameObject.FindWithTag("Rj45_568B")){
            m.AddElements(10 , 1);
            GameObject.Destroy(GameObject.FindWithTag("Rj45_568B"));  
            m.SaveItem();         
        }
        else if( GameObject.FindWithTag("Rj45_568A")){
            m.AddElements(9, 1);
            GameObject.Destroy(GameObject.FindWithTag("Rj45_568A"));
            m.SaveItem();
        }
        else if( GameObject.FindWithTag("Rj45_")){
            m.AddElements(3, 1);
            GameObject.Destroy(GameObject.FindWithTag("Rj45_"));
            m.SaveItem();
        }
    }
}
