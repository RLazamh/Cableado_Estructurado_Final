using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterCreator : MonoBehaviour
{
    // Start is called before the first frame update
    Ray ray, ray2;
    RaycastHit hit;
    public GameObject newObject;
    public GameObject gutterUnion;
    public Camera cam;
    public Camera FPS_Camera;
    public InventoryManager inventoryManager;
    public GameObject Indications;
    public GameObject t;
    public GameObject gutter_floor;
    public GameObject prueba1;
    public GameObject prueba2;
    public GameObject prueba3;
    public GameObject prueba4;
    public GameObject prueba5;
    public GameObject prueba6;
    public GameObject prueba7;
    public GameObject prueba8;
    public GameObject prueba9;
    public GameObject prueba10;
    public GameObject prueba11;
    public GameObject prueba12;
    public GameObject prueba13;
    public GameObject prueba14;
    public GameObject Rack;
    public GameObject path1;
    public GameObject patch2;
    public GameObject active;
    public GameObject conexion;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("gutter"))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            ray2 = FPS_Camera.ScreenPointToRay(Input.mousePosition);
            ray = ray2;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "verticalGutter")
                {
                    newObject.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(newObject, hit.collider.transform.position, Quaternion.Euler(0, 0, 180));
                    newGutter.transform.SetParent(GameObject.FindWithTag("realCeiling").transform, true);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                }
                if (hit.collider.tag == "horizontalGutter")
                {
                    newObject.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(newObject, hit.collider.transform.position, Quaternion.Euler(0, 90, 180));
                    newGutter.transform.SetParent(GameObject.FindWithTag("realCeiling").transform, true);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                }
                if (hit.collider.tag == "GutterIntersection")
                {

                    if (GameObject.FindWithTag("NewObject"))
                    {
                        Debug.Log("Debe seleccionar un objeto del inventario");
                    }
                    else
                    {
                        GameObject newUnion = Instantiate(gutterUnion, hit.collider.transform.position, Quaternion.Euler(180, 90, 0));
                        newUnion.transform.SetParent(GameObject.FindWithTag("realCeiling").transform, true);
                        hit.collider.tag = "Untagged";
                        GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                        GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                        inventoryManager.DeleteElements(1, 1);
                        Indications.SetActive(false);
                    }
                }
                if (hit.collider.tag == "horizontalFloor")
                {
                    newObject.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(newObject, hit.collider.transform.position, Quaternion.Euler(0, 90, 0));
                    newGutter.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                }

                if (hit.collider.tag == "verticalFloor")
                {
                    newObject.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(newObject, hit.collider.transform.position, Quaternion.Euler(0, 0, 0));
                    newGutter.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                }

                if (hit.collider.tag == "GutterIntersectionFloor")
                {

                    if (GameObject.FindWithTag("NewObject"))
                    {
                        Debug.Log("Debe seleccionar un objeto del inventario");
                    }
                    else
                    {
                        GameObject newUnion = Instantiate(gutterUnion, hit.collider.transform.position, Quaternion.Euler(0, 90, 0));
                        newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                        hit.collider.tag = "Untagged";
                        GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                        GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                        inventoryManager.DeleteElements(1, 1);
                        Indications.SetActive(false);
                    }
                }

                /*if (hit.collider.tag == "GutterIntersectionRackFloor")
                {

                    if (GameObject.FindWithTag("NewObject"))
                    {
                        Debug.Log("Debe seleccionar un objeto del inventario");
                    }
                    else
                    {
                        GameObject newUnion = Instantiate(gutterUnion, hit.collider.transform.position, Quaternion.Euler(90, 0, 90));
                        newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                        hit.collider.tag = "Untagged";
                        GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                        GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                        inventoryManager.DeleteElements(0, 1);
                        Indications.SetActive(false);
                    }
                }*/
                if (hit.collider.tag == "column")
                {
                    if (GameObject.FindWithTag("NewObject"))
                    {
                        Debug.Log("Debe seleccionar un objeto del inventario");

                    }
                    else
                    {
                        newObject.transform.localScale = hit.collider.transform.localScale;
                        GameObject newGutter = Instantiate(newObject, hit.collider.transform.position, Quaternion.Euler(0, 0, 90));
                        newGutter.transform.SetParent(hit.collider.transform);
                        hit.collider.tag = "Untagged";
                        Indications.SetActive(false);
                        GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                        GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                        inventoryManager.DeleteElements(0, 1);
                        inventoryManager.SaveItem();

                    }
                }
//**********************************************************************************************Conexion*///////
               






            }
        }

        ////***************************************************************************************************************
        if (Input.GetMouseButton(0))  // funcion colacion de  rack
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            ray2 = FPS_Camera.ScreenPointToRay(Input.mousePosition);
            ray = ray2;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {

                Debug.Log(hit.collider.name);
                if (GameObject.FindWithTag("NewObject"))
                {
                    Debug.Log("Debe  seleccionarce un objeto de inventario");

                }


                else if (hit.collider.tag == "conexion" && FindGameObjectInChildWithTag(active, "prueba13"))
                {
                    Debug.Log("Hay contacto");
                    GameObject newUnion = Instantiate(Rack, new Vector3(hit.collider.transform.position.x + 7, hit.collider.transform.position.y + 1, hit.collider.transform.position.z - 11), Quaternion.Euler(0, -90, 0)); //  intanciamos el rack
                    newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                    //hit.collider.tag = "Untagged";   Para permitirme  hacer una  nueva  conexion
                    newUnion.gameObject.tag = "Rack";
                    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                    inventoryManager.DeleteElements(1, 1);
                    Indications.SetActive(false);
                }
                else if(hit.collider.tag == "conexion" && FindGameObjectInChildWithTag(active, "prueba13"))
                {

                    newObject.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(conexion, hit.collider.transform.position, Quaternion.Euler(-90, 180, 0));
                    newGutter.transform.SetParent(hit.collider.transform);
                    hit.collider.tag = "PuntoConexion";
                    Indications.SetActive(false);
                    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                    inventoryManager.DeleteElements(0, 1);
                    inventoryManager.SaveItem();



                }



            }
        }

        //************************************************ Patch 1**************

        if (Input.GetMouseButton(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {

                if (GameObject.FindWithTag("NewObject"))
                {
                    Debug.Log(" Debe  seleccionarse un objeto del inventario");
                }

                else if (hit.collider.tag == "Slot" &&FindGameObjectInChildWithTag(active, "Patch_1RU"))
                {

                    GameObject cuboTemp = Instantiate(path1, hit.collider.transform.position, Quaternion.Euler(-90, 0, 0));
                    Debug.Log(" Se ha  colcado");

                    cuboTemp.transform.SetParent(hit.collider.transform);
                    //Debug.Log(" Se ha  tocado");
                    //Vector3 dimension = newgameObject.transform.localScale;
                    //newgameObject.transform.localScale = dimension;
                    //Instantiate(newgameObject, hit.point, Quaternion.Euler(90,0,0) );
                    hit.collider.tag = "SlotOcupado";

                    //*Codgo modificado

                    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                    inventoryManager.DeleteElements(1, 1);
                    Indications.SetActive(false);

                }

            }

        }


        //*********************** Patch2****************************************
        if (Input.GetMouseButton(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (GameObject.FindWithTag("NewObject"))
                {
                    Debug.Log("Debe seleccionarse un objeto del inventario");
                } 
               else if(hit.collider.tag =="Slot2" && FindGameObjectInChildWithTag(active,"Patch_2RU"))
                {
                    GameObject cuboTemp2 = Instantiate(patch2, hit.collider.transform.position,Quaternion.Euler(-90,0,0));
                    Debug.Log(" Se ha  colcado");
                    cuboTemp2.transform.SetParent(hit.collider.transform);
                    //cuboTemp2.transform.parent = padrePatch.transform;
                    //Debug.Log(" Se ha  tocado");
                    //Vector3 dimension = newgameObject.transform.localScale;
                    //newgameObject.transform.localScale = dimension;
                    //Instantiate(newgameObject, hit.point, Quaternion.Euler(90,0,0) );
                    hit.collider.tag = "SlotOcupado";
                    //*Codigo modificado 

                    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                    inventoryManager.DeleteElements(1, 1);
                    Indications.SetActive(false);


                }


            }


        }
    
        //***************************************************************PUNTO DE CONEXION *********************************************************
















     




        if (Input.GetMouseButton(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            ray2 = FPS_Camera.ScreenPointToRay(Input.mousePosition);
            ray = ray2;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "horizontalFloor" && FindGameObjectInChildWithTag(active, "prueba13"))
                {

                    prueba14.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(prueba14, hit.collider.transform.position, Quaternion.Euler(0, 90, 0));
                    newGutter.transform.SetParent(hit.collider.transform);
                    hit.collider.tag = "cable_horizontal";
                    Indications.SetActive(false);
                    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                    inventoryManager.DeleteElements(0, 1);
                    inventoryManager.SaveItem();
                }
                if (hit.collider.tag == "verticalFloor" && FindGameObjectInChildWithTag(active, "prueba13"))
                {

                    prueba13.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(prueba13, hit.collider.transform.position, Quaternion.Euler(0, 0, 0));
                    newGutter.transform.SetParent(hit.collider.transform);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                    inventoryManager.DeleteElements(0, 1);
                    inventoryManager.SaveItem();
                }
                if (hit.collider.tag == "verticalGutter" && FindGameObjectInChildWithTag(active, "prueba13"))
                {
                    newObject.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(newObject, hit.collider.transform.position, Quaternion.Euler(0, 0, 180));
                    newGutter.transform.SetParent(GameObject.FindWithTag("realCeiling").transform, true);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                }
                if (hit.collider.tag == "horizontalGutter" && FindGameObjectInChildWithTag(active, "prueba13"))
                {
                    newObject.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(newObject, hit.collider.transform.position, Quaternion.Euler(0, 90, 180));
                    newGutter.transform.SetParent(GameObject.FindWithTag("realCeiling").transform, true);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                }
                if (hit.collider.tag == "conexion" && FindGameObjectInChildWithTag(active, "conexion"))
                {

                   // conexion.transform.localScale = hit.collider.transform.localScale;
                    GameObject newGutter = Instantiate(conexion, new Vector3(hit.collider.transform.position.x+0,hit.collider.transform.position.y+0,hit.collider.transform.position.z-0.5f), Quaternion.Euler(-90, 0, 0));
                    newGutter.transform.SetParent(hit.collider.transform);
                    hit.collider.tag = "Untagged";
                    Indications.SetActive(false);
                    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                    inventoryManager.DeleteElements(0, 1);
                    inventoryManager.SaveItem();
                }


                if (hit.collider.tag == "GutterIntersectionFloor")
                {

                    if (GameObject.FindWithTag("NewObject"))
                    {
                        Debug.Log("Debe seleccionar un objeto del inventario");
                    }
                    else
                    {
                        if (FindGameObjectInChildWithTag(active, "prueba1"))
                        {
                            GameObject newUnion = Instantiate(prueba1, new Vector3(hit.collider.transform.position.x + 0, hit.collider.transform.position.y + 0, hit.collider.transform.position.z + 0.2f), Quaternion.Euler(-180, 0, 0));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);

                        }

                        if (FindGameObjectInChildWithTag(active, "prueba2"))
                        {
                            GameObject newUnion = Instantiate(prueba2, new Vector3(hit.collider.transform.position.x + 0.2f, hit.collider.transform.position.y + 0, hit.collider.transform.position.z + 0.2f), Quaternion.Euler(-180, 90, 0));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);


                        }
                        if (FindGameObjectInChildWithTag(active, "prueba3"))
                        {
                            GameObject newUnion = Instantiate(prueba3, new Vector3(hit.collider.transform.position.x + 0.2f, hit.collider.transform.position.y + 0, hit.collider.transform.position.z - 0.2f), Quaternion.Euler(-180, 180, 0));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);




                        }
                        if (FindGameObjectInChildWithTag(active, "prueba4"))
                        {
                            GameObject newUnion = Instantiate(prueba4, new Vector3(hit.collider.transform.position.x + 0, hit.collider.transform.position.y + 0, hit.collider.transform.position.z + 0), Quaternion.Euler(-180, -90, 0));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);


                        }

                        if (FindGameObjectInChildWithTag(active, "prueba5"))
                        {
                            GameObject newUnion = Instantiate(prueba5, new Vector3(hit.collider.transform.position.x - 0.1f, hit.collider.transform.position.y + 0, hit.collider.transform.position.z + 0), Quaternion.Euler(-270, 0, -90));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);


                        }
                        if (FindGameObjectInChildWithTag(active, "prueba6"))
                        {
                            GameObject newUnion = Instantiate(prueba6, new Vector3(hit.collider.transform.position.x - 0.1f, hit.collider.transform.position.y + 0, hit.collider.transform.position.z + 0), Quaternion.Euler(-270, 0, 90));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);

                        }
                        if (FindGameObjectInChildWithTag(active, "prueba7"))
                        {
                            GameObject newUnion = Instantiate(prueba7, new Vector3(hit.collider.transform.position.x - 0.1f, hit.collider.transform.position.y + 0, hit.collider.transform.position.z + 0.1f), Quaternion.Euler(-270, 0, -180));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);

                        }
                        if (FindGameObjectInChildWithTag(active, "prueba8"))
                        {
                            GameObject newUnion = Instantiate(prueba8, new Vector3(hit.collider.transform.position.x - 0.1f, hit.collider.transform.position.y + 0, hit.collider.transform.position.z + 0.1f), Quaternion.Euler(-270, 0, 0));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);


                        }
                        if (FindGameObjectInChildWithTag(active, "prueba9"))
                        {
                            GameObject newUnion = Instantiate(prueba9, new Vector3(hit.collider.transform.position.x + 5, hit.collider.transform.position.y - 2, hit.collider.transform.position.z + 7), Quaternion.Euler(0, 0, 180));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);

                        }
                        if (FindGameObjectInChildWithTag(active, "prueba10"))
                        {
                            GameObject newUnion = Instantiate(prueba10, new Vector3(hit.collider.transform.position.x - 11, hit.collider.transform.position.y - 2, hit.collider.transform.position.z - 7), Quaternion.Euler(0, -180, -180));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);


                        }

                        if (FindGameObjectInChildWithTag(active, "prueba11"))
                        {
                            GameObject newUnion = Instantiate(prueba11, new Vector3(hit.collider.transform.position.x - 7, hit.collider.transform.position.y - 2, hit.collider.transform.position.z + 11), Quaternion.Euler(0, -90, -180));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);



                        }

                        if (FindGameObjectInChildWithTag(active, "prueba12"))
                        {
                            GameObject newUnion = Instantiate(prueba12, new Vector3(hit.collider.transform.position.x + 7, hit.collider.transform.position.y - 2, hit.collider.transform.position.z - 11), Quaternion.Euler(0, -270, -180));
                            newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                            hit.collider.tag = "Untagged";
                            newUnion.gameObject.tag = "Golpe";
                            GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                            GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                            inventoryManager.DeleteElements(1, 1);
                            Indications.SetActive(false);


                        }


                        if (FindGameObjectInChildWithTag(active, "Patch_1RU"))
                        {




                        }

                        //if (FindGameObjectInChildWithTag(active, "prueba13"))
                        //{
                        //    GameObject newUnion = Instantiate(Rack, new Vector3(hit.collider.transform.position.x + 7, hit.collider.transform.position.y - 2, hit.collider.transform.position.z - 11), Quaternion.Euler(0, -270, -180));
                        //    newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                        //    hit.collider.tag = "Untagged";
                        //    newUnion.gameObject.tag = "Golpe";
                        //    GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                        //    GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                        //    inventoryManager.DeleteElements(1, 1);
                        //    Indications.SetActive(false);

                    

                        //}
                        

                    }
                }

            }


        }
        if (Input.GetMouseButton(1))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            ray2 = FPS_Camera.ScreenPointToRay(Input.mousePosition);
            ray = ray2;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.tag == "GutterIntersectionFloor")
                {

                    if (GameObject.FindWithTag("NewObject"))
                    {
                        Debug.Log("Debe seleccionar un objeto del inventario");
                    }
                    else
                    {
                        GameObject newUnion = Instantiate(t, new Vector3(hit.collider.transform.position.x + 2, hit.collider.transform.position.y + 5, hit.collider.transform.position.z + 7), Quaternion.Euler(0, 0, -90));
                        newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                        hit.collider.tag = "Untagged";
                        newUnion.gameObject.tag = "Golpe";
                        GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                        GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                        inventoryManager.DeleteElements(0, 1);
                        Indications.SetActive(false);
                    }
                }

            }


        }
        if (Input.GetMouseButton(2))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            ray2 = FPS_Camera.ScreenPointToRay(Input.mousePosition);
            ray = ray2;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.tag == "GutterIntersectionFloor")
                {

                    if (GameObject.FindWithTag("NewObject"))
                    {
                        Debug.Log("Debe seleccionar un objeto del inventario");
                    }
                    else
                    {
                         GameObject newUnion = Instantiate(gutter_floor, hit.collider.transform.position, Quaternion.Euler(-180, 0, 0));
                         newUnion.transform.SetParent(GameObject.FindWithTag("realFloor").transform, true);
                         hit.collider.tag = "Untagged";

                         GameObject.Destroy(GameObject.FindWithTag("NewObjectNULL").transform.GetChild(0).gameObject);
                         GameObject.FindWithTag("NewObjectNULL").tag = "NewObject";
                         inventoryManager.DeleteElements(1, 1);
                         Indications.SetActive(false);

                       







                    }
                }

            }

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