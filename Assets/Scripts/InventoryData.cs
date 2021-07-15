using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData 
{

    public InventaryObjectId[] inventaryObjectId;
    

}
[System.Serializable]
    public struct  InventaryObjectId
    {
        public int id;
        public int quantity;
        
     

        public InventaryObjectId(int id, int quantity)
        {
            this.id = id;
            this.quantity = quantity;
            
         
        }
    }
