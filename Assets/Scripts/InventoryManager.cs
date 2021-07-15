using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class InventoryManager : MonoBehaviour
{
    public InventoryCanvas inventoryCanvas;
    public InventoryData inventoryData;

    public GameObject Indications;
    void Awake(){
        
        //LoadItems();
    }

    

    public void Start()
    {
        
        UpdateInventory();
     
    }

    public DataBaseInventory dataBase;
    public List<InventaryObjectId> Inventory;
    
    public void AddElements(int id, int quantity)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].id == id)
            {
                Inventory[i] = new InventaryObjectId(Inventory[i].id, Inventory[i].quantity + quantity);
                UpdateInventory();
                return;
            }
        }
        
        Inventory.Add(new InventaryObjectId(id, quantity)); 
        UpdateInventory();
        
    }

    public void DeleteElements(int id, int quantity)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].id == id)
            {
                Inventory[i] = new InventaryObjectId(Inventory[i].id, Inventory[i].quantity - quantity);
                if (Inventory[i].quantity <= 0)
                    Inventory.Remove(Inventory[i]);
                    UpdateInventory();
                    return;
            }
        }
        Debug.LogError("No existe el objeto a eliminar");

    }

    public void ExchangePositions(int i1 , int i2)
    {
        InventaryObjectId i = Inventory[i1];
        Inventory[i1] = Inventory[i2];
        Inventory[i2] = i;
        UpdateInventory();
    }

    public InventoryObjectInterface prefab;
    public Transform inventoryUI;
    List<InventoryObjectInterface> pool = new List<InventoryObjectInterface>();

    public void UpdateInventory()
    {

        for (int i = 0; i < pool.Count; i++)
        {
            if (i < Inventory.Count)
            {
                InventaryObjectId o = Inventory[i];
                pool[i].sprite.sprite = dataBase.dataBase[o.id].sprite;
                pool[i].quantity.text = o.quantity.ToString();
                pool[i].NameSlot.text = dataBase.dataBase[o.id].name;

                pool[i].id = i;
                pool[i].button.onClick.RemoveAllListeners();
                pool[i].button.onClick.AddListener(() => gameObject.SendMessage(dataBase.dataBase[o.id].funtion, SendMessageOptions.DontRequireReceiver));
                
                pool[i].gameObject.SetActive(true);
                
            }
            else
            {
                pool[i].gameObject.SetActive(false);
            }
        } 
        if (Inventory.Count > pool.Count)
        {
            for (int i = pool.Count; i < Inventory.Count; i++)
            {
                InventoryObjectInterface oi = Instantiate(prefab, inventoryUI);
                pool.Add(oi);

                oi.transform.position = Vector3.zero; 
                oi.transform.localScale = Vector3.one;

                InventaryObjectId o = Inventory[i];
                pool[i].sprite.sprite = dataBase.dataBase[o.id].sprite;
                pool[i].quantity.text = o.quantity.ToString();
                pool[i].NameSlot.text = dataBase.dataBase[o.id].name;
                pool[i].id = i;
                pool[i].manager = this;
                pool[i].button.onClick.RemoveAllListeners();
                pool[i].button.onClick.AddListener(() => gameObject.SendMessage(dataBase.dataBase[o.id].funtion, SendMessageOptions.DontRequireReceiver));

                pool[i].gameObject.SetActive(true);
            }

        
        }

       
    }
    public void GutterUse()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[0].prefab, GameObject.FindWithTag("NewObject").transform.position , Quaternion.Euler(0, 0, 90));
        prefabElement.gameObject.tag = "prueba13";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.010f,0.015f, 0.015f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        //DeleteElements(0, 1);
        inventoryCanvas.Inventario.SetActive(false);  
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
        
        //Debug.log (Application.persistentDataPath);
    }
    //public void ElbowGutterUse()
    //{
    //    GameObject prefabElement = Instantiate(dataBase.dataBase[1].prefab, GameObject.FindWithTag("NewObject").transform.position , Quaternion.Euler(90, 0, 90));
    //    prefabElement.gameObject.tag = "Golpe";
    //    prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
    //    prefabElement.transform.localScale = new Vector3(0.05f,0.05f, 0.05f);
    //    GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
    //    inventoryCanvas.Inventario.SetActive(false);  
    //    inventoryCanvas.Scroll.SetActive(false);
    //    Indications.SetActive(!Indications.activeInHierarchy);
    //    Cursor.lockState = CursorLockMode.Locked;
    //}
    public void ElbowGutterRight1()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[1].prefab, GameObject.FindWithTag("NewObject").transform.position , Quaternion.Euler(0, 0, 0));
        prefabElement.gameObject.tag = "prueba1";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f,0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);  
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    
    }
    public void ElbowGutterLeft1()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[2].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0, 0, 0));
        prefabElement.gameObject.tag = "prueba2";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void ElbowGutterLeft2()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[3].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0,0 ,0));
        prefabElement.gameObject.tag = "prueba3";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void ElbowGutterRight2()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[4].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0, 0, 0));
        prefabElement.gameObject.tag = "prueba4";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void ElbowGutterVertical1()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[5].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0, 0, 0));
        prefabElement.gameObject.tag = "prueba5";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void ElbowGutterVertical2()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[6].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0, 0, 0));
        prefabElement.gameObject.tag = "prueba6";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void ElbowGutterVertical3()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[7].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(-0, 0, 0));
        prefabElement.gameObject.tag = "prueba7";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void ElbowGutterVertical4()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[8].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0, 0, 0));
        prefabElement.gameObject.tag = "prueba8";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void TGutter1()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[12].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0,0,-180));
        prefabElement.gameObject.tag = "prueba9";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void TGutter2()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[13].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0,-180,-180));
        prefabElement.gameObject.tag = "prueba10";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void TGutter3()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[14].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0,-90,-180));
        prefabElement.gameObject.tag = "prueba11";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void TGutter4()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[15].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0,-270,-180));
        prefabElement.gameObject.tag = "prueba12";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Rj45A()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[9].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0, 270,0));
        prefabElement.gameObject.tag = "cable_prueba";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Rack()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[16].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(0, -270, -180));
        prefabElement.gameObject.tag = "prueba13";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Conexion()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[19].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(270, -180, -180));
        prefabElement.gameObject.tag = "conexion";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Patch1()
    {

        GameObject prefabElement = Instantiate(dataBase.dataBase[17].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(270, -180, -180));
        prefabElement.gameObject.tag = "Patch_1RU";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Patch2()
    {
        GameObject prefabElement = Instantiate(dataBase.dataBase[18].prefab, GameObject.FindWithTag("NewObject").transform.position, Quaternion.Euler(270, -180, -180));
        prefabElement.gameObject.tag = "Patch_2RU";
        prefabElement.transform.SetParent(GameObject.FindWithTag("NewObject").transform, true);
        prefabElement.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        GameObject.FindWithTag("NewObject").tag = "NewObjectNULL";
        inventoryCanvas.Inventario.SetActive(false);
        inventoryCanvas.Scroll.SetActive(false);
        Indications.SetActive(!Indications.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Locked;


    }

    





    public  void SaveItem(){

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Data.txt";
        FileStream fStream = new FileStream(path, FileMode.Create);
        formatter.Serialize(fStream,Inventory);
        fStream.Close();
    }

    public List<InventaryObjectId> LoadItems()
    {
        string path = Application.persistentDataPath + "/Data.txt";
        if(File.Exists(path))
        {
             BinaryFormatter formatter = new BinaryFormatter();
             FileStream fStream = new FileStream(path, FileMode.Open);
             Inventory = (List<InventaryObjectId>)formatter.Deserialize(fStream); //as InventoryData;
             return Inventory;

        }
        else
        {
            SaveItem();
            return null;
 
        }
    }
}