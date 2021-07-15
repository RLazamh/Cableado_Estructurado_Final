using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]

public class DataBaseInventory : ScriptableObject
{
    public InventoryObject[] dataBase;
}

[System.Serializable]
public struct InventoryObject
{
        public string name;
        public Sprite sprite;
        public string funtion;
        public GameObject prefab;
        


}  

