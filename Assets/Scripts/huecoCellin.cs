using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huecoCellin : MonoBehaviour
{

    public GameObject sueloHueco;
    public GameObject guia;
    public GameObject coll;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Golpe")
        {
            print("Suelo");
            Instantiate(sueloHueco, transform.position, transform.rotation, guia.transform.parent);
            Destroy(gameObject);
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.GetComponent<Collider>());
        }
        // if(collision.gameObject.tag == "Golpe")
        //{
        //Destroy(gameObject);
        //Instantiate(sueloHueco, transform.position, Quaternion.identity);
        //}


    }
    




}
