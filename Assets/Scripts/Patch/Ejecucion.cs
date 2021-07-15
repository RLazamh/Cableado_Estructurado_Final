using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ejecucion : MonoBehaviour
{

    public GameObject prefab;    //Crea un GameObject publico para colocar el prefab que desamos instanciar

    public void CrearRj45()
    {

        Debug.Log(" Se ha presionado el boton", gameObject);    //Mostrar en consola si se ha presionado el botón 


        Vector3 randomSpawn = new Vector3(UnityEngine.Random.Range(-7.5f,-5.5f),2.70f,-1.35f);     //Se crea unaposicion al azar de forma horizontal. 
        GameObject newGO = Instantiate(prefab, randomSpawn, Quaternion.Euler(0, 0, 0));        //Se coloca el prefab en la posicion requerida
        Rigidbody rb = newGO.GetComponent<Rigidbody>();     //Se extrae los componentes del RigidBody puesto en le prefab
        if(rb == null)
        {
            rb = newGO.AddComponent<Rigidbody>();           //Agregamos a la variable que se creó los componentes del Rigidbody.
        }

        rb.useGravity = false;      //Se desactiva la gravedad para que no caiga el objeto al vacio 
        rb.isKinematic = true;
    }

    




}
 